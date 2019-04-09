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
        }

        public bool HasUnfinishedGame()
        {
            Game unfinishedGame = _gameRepository.GetUnfinishedGame(_user.Id);
            return unfinishedGame != null;
        }

        public void NewGame(int botCount)
        {
            EndGame();

            var game = new Game();
            _gameRepository.Add(game);

            int availableBotCount = _playerRepository.GetBotCount();
            if (availableBotCount < botCount)
            {
                CreateBots(availableBotCount, botCount);
            }

            CreateRound(game.Id, botCount);
        }

        public List<RoundViewModel> GetRoundsInfo()
        {
            Game game = _gameRepository.GetUnfinishedGame(_user.Id);
            List<Round> lastRounds = _roundRepository.GetLastRounds(game.Id);

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
            Game game = _gameRepository.GetUnfinishedGame(_user.Id);
            List<Round> rounds = _roundRepository.GetLastRounds(game.Id);
            List<long> shuffledCards = GetShuffledCards(rounds);

            Round round = _roundRepository.GetLastRound(_user.Id);

            var roundCard = new RoundCard { RoundId = round.Id, CardId = shuffledCards[0] };
            _roundCardRepository.Add(roundCard);

            List<Card> cards = _cardRepository.GetCards(round.Id);
            int score = CalculateCardScore(cards);
            if (score >= 21)
            {
                CreateNonPlayableCards(rounds);
                UpdateRounds(rounds);
            }
        }

        public void EndRound()
        {
            Game game = _gameRepository.GetUnfinishedGame(_user.Id);
            List<Round> rounds = _roundRepository.GetLastRounds(game.Id);
            CreateNonPlayableCards(rounds);
            UpdateRounds(rounds);
        }

        public void NextRound()
        {

        }

        public void EndGame()
        {
            Game unfinishedGame = _gameRepository.GetUnfinishedGame(_user.Id);
            FinishGame(unfinishedGame);
        }

        #region Private methods
        private void FinishGame(Game game)
        {
            if (game != null)
            {
                game.IsFinished = true;
                _gameRepository.Update(game);
            }
        }

        private RoundViewModel GetRoundInfo(Round round)
        {
            Player player = _playerRepository.GetPlayer(round.Id);
            PlayerViewModel playerViewModel = new PlayerViewModel { Name = player.Name, Type = player.Type };

            List<Card> cards = _cardRepository.GetCards(round.Id);
            List<CardViewModel> cardViewModels = new List<CardViewModel>();
            foreach (var card in cards)
            {
                var cardViewModel = new CardViewModel { Card = CardHelper.GetCard(card.Suit, card.Rank) };
                cardViewModels.Add(cardViewModel);
            }
            if (round.PlayerId == BlackJackConstants.DealerId && cards.Count == 2)
            {
                cardViewModels[1].Card = CardHelper.BlankCard;
            }

            var roundViewModel = new RoundViewModel { Player = playerViewModel, Cards = cardViewModels, State = round.State };
            return roundViewModel;
        }

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

        private void CreateRound(long gameId, int neededBotCount)
        {
            List<Player> bots = _playerRepository.GetBots(neededBotCount);

            Round userRound = new Round { GameId = gameId, PlayerId = _user.Id };
            Round dealerRound = new Round { GameId = gameId, PlayerId = BlackJackConstants.DealerId };
            var rounds = new List<Round> { userRound, dealerRound };
            foreach (var bot in bots)
            {
                Round botRound = new Round { GameId = gameId, PlayerId = bot.Id };
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
                var ace = cards.FirstOrDefault(card => card.Rank == Rank.Ace);
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

            List<Card> dealerCards = _cardRepository.GetCards(dealerRound.Id);
            int dealerScore = CalculateCardScore(dealerCards);
            if (dealerScore > 21)
            {
                // TODO
                return;
            }

            foreach (var round in rounds)
            {
                List<Card> cards = _cardRepository.GetCards(round.Id);
                int score = CalculateCardScore(cards);
                if (score > 21)
                {
                    round.State = RoundState.Lose;
                    continue;
                }
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
            rounds.Add(dealerRound);

            _roundRepository.Update(rounds);
        }
        #endregion
    }
}
