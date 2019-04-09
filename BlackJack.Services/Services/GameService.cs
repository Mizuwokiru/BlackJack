using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Helpers;
using BlackJack.ViewModels.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Services.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IRoundCardRepository _roundCardRepository;
        private readonly Player _user;
        private Game _game;

        public GameService(IGameRepository gameRepository,
            IPlayerRepository playerRepository,
            IRoundRepository roundRepository,
            ICardRepository cardRepository,
            IRoundCardRepository roundCardRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _roundRepository = roundRepository;
            _cardRepository = cardRepository;
            _roundCardRepository = roundCardRepository;
            _user = _playerRepository.GetUser(httpContextAccessor.HttpContext.User.Identity.Name);
            _game = _gameRepository.GetUnfinishedGame(_user.Id);
        }

        public bool HasUnfinishedGame()
        {
            return _game != null;
        }

        public void NewGame(int neededBotCount)
        {
            EndGame();

            _game = new Game();
            _gameRepository.Add(_game);

            int availableBotCount = _playerRepository.GetBotCount();
            if (availableBotCount < neededBotCount)
            {
                CreateBots(availableBotCount, neededBotCount);
            }

            CreateRound(neededBotCount);
        }

        public List<RoundViewModel> GetRoundsInfo()
        {
            List<Round> lastRounds = _roundRepository.GetLastRounds(_game.Id);

            var roundViewModels = new List<RoundViewModel>();
            foreach (var round in lastRounds)
            {
                RoundViewModel roundViewModel = GetRoundInfo(round);
                roundViewModels.Add(roundViewModel);
            }

            return roundViewModels;
        }

        public void Step()
        {
            List<Round> rounds = _roundRepository.GetLastRounds(_game.Id);
            List<long> shuffledCards = GetShuffledCards(rounds);

            Round round = _roundRepository.GetLastRound(_user.Id);

            var roundCard = new RoundCard { RoundId = round.Id, CardId = shuffledCards[0] };
            _roundCardRepository.Add(roundCard);
        }

        public void EndRound()
        {
            List<Round> rounds = _roundRepository.GetLastRounds(_game.Id);
            CreateNonPlayableCards(rounds);
            UpdateRounds(rounds);
        }

        public void NextRound()
        {
            List<Round> lastRounds = _roundRepository.GetLastRounds(_game.Id);
            CreateRound(lastRounds.Count);
        }

        public void EndGame()
        {
            if (_game != null)
            {
                _game.IsFinished = true;
                _gameRepository.Update(_game);
            }
        }

        #region Private methods
        private void CreateBots(int availableBotCount, int neededBotCount)
        {
            var bots = new List<Player>();
            for (int i = availableBotCount; i < neededBotCount; i++)
            {
                var bot = new Player { Name = $"Bot №{i + 1}", Type = PlayerType.Bot };
                bots.Add(bot);
            }
            _playerRepository.Add(bots);
        }

        // TODO: Remove it and use Join
        private RoundViewModel GetRoundInfo(Round round)
        {
            Player player = _playerRepository.GetPlayer(round.Id);
            PlayerViewModel playerViewModel = new PlayerViewModel { Name = player.Name, Type = player.Type };

            List<Card> cards = _cardRepository.GetCards(round.Id);
            List<CardViewModel> cardViewModels = new List<CardViewModel>();
            foreach (var card in cards)
            {
                // TODO: Hide last card, if its dealer and he's 2 cards.
                var cardViewModel = new CardViewModel { Suit = card.Suit, Rank = card.Rank };
                cardViewModels.Add(cardViewModel);
            }

            int score = CalculateCardScore(cards);

            var roundViewModel = new RoundViewModel { Player = playerViewModel, Cards = cardViewModels, State = round.State, Score = score };
            return roundViewModel;
        }

        private void CreateRound(int neededBotCount)
        {
            List<Player> bots = _playerRepository.GetBots(neededBotCount);

            Round userRound = new Round { GameId = _game.Id, PlayerId = _user.Id };
            Round dealerRound = new Round { GameId = _game.Id, PlayerId = BlackJackConstants.DealerId };
            var rounds = new List<Round> { userRound, dealerRound };
            foreach (var bot in bots)
            {
                Round botRound = new Round { GameId = _game.Id, PlayerId = bot.Id };
                rounds.Add(botRound);
            }
            _roundRepository.Add(rounds);

            CreateCards(rounds);
        }

        private void CreateCards(List<Round> rounds)
        {
            var roundCards = new List<RoundCard>();
            var shuffledCards = GetShuffledCards();
            for (int i = 0; i < rounds.Count; i++)
            {
                RoundCard firstCard = new RoundCard { RoundId = rounds[i].Id, CardId = shuffledCards[i] };
                RoundCard secondCard = new RoundCard { RoundId = rounds[i].Id, CardId = shuffledCards[i + rounds.Count] };
                roundCards.AddRange(new[] { firstCard, secondCard });
            }
            _roundCardRepository.Add(roundCards);
        }

        private List<long> GetShuffledCards(List<Round> rounds = null)
        {
            var cardIds = new List<long>();
            for (int i = 0; i < BlackJackConstants.DeckCount; i++)
            {
                IEnumerable<long> deck = Enumerable.Range(1, BlackJackConstants.DeckCapacity)
                    .Select(cardId => (long)cardId);
                cardIds.AddRange(deck);
            }

            if (rounds != null)
            {
                List<Card> cards = _cardRepository.GetCards(rounds);
                foreach (var card in cards)
                {
                    cardIds.Remove(card.Id);
                }
            }

            var random = new Random();
            for (int i = cardIds.Count - 1, j; i > 0; i--)
            {
                j = random.Next(i + 1);
                long tmp = cardIds[i];
                cardIds[i] = cardIds[j];
                cardIds[j] = tmp;
            }

            return cardIds;
        }

        private static int CalculateCardScore(List<Card> cards)
        {
            int score = 0;
            foreach (var card in cards)
            {
                score += CardHelper.GetCardScore(card.Rank);
            }
            while (score > 21)
            {
                Card ace = cards.FirstOrDefault(card => card.Rank == Rank.Ace);
                if (ace == null)
                {
                    break;
                }
                cards.Remove(ace);
                score -= 10;
            }
            return score;
        }

        private void CreateNonPlayableCards(List<Round> rounds)
        {
            // TODO: some AI for bots and dealer
        }

        private void UpdateRounds(List<Round> rounds)
        {
            Round dealerRound = rounds
                .Where(round => round.PlayerId == BlackJackConstants.DealerId)
                .First();
            rounds.Remove(dealerRound);

            CheckOverkills(rounds);

            List<Card> dealerCards = _cardRepository.GetCards(dealerRound.Id);
            int dealerScore = CalculateCardScore(dealerCards);
            if (dealerScore > 21)
            {
                SetWinners(rounds);
            }
            if (dealerScore <= 21)
            {
                CheckStates(rounds, dealerScore);
            }
            _roundRepository.Update(rounds);
        }

        private void CheckOverkills(List<Round> rounds)
        {
            foreach (var round in rounds)
            {
                List<Card> cards = _cardRepository.GetCards(round.Id);
                int score = CalculateCardScore(cards);
                if (score > 21)
                {
                    round.State = RoundState.Lose;
                }
            }
        }

        private void SetWinners(List<Round> rounds)
        {
            foreach (var round in rounds)
            {
                if (round.State != RoundState.None)
                {
                    continue;
                }
                round.State = RoundState.Won;
            }
        }

        private void CheckStates(List<Round> rounds, int dealerScore)
        {
            foreach (var round in rounds)
            {
                if (round.State != RoundState.None)
                {
                    continue;
                }
                List<Card> cards = _cardRepository.GetCards(round.Id);
                int score = CalculateCardScore(cards);
                if (score > dealerScore)
                {
                    round.State = RoundState.Won;
                }
                if (score == dealerScore)
                {
                    round.State = RoundState.Push;
                }
                if (score < dealerScore)
                {
                    round.State = RoundState.Lose;
                }
            }
        }
        #endregion
    }
}
