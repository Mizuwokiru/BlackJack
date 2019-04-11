using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
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

        public IEnumerable<RoundViewModel> GetRoundsInfo()
        {
            IEnumerable<RoundInfoModel> roundInfoModels = _roundRepository.GetLastRoundsInfo(_game.Id);
            
            IEnumerable<RoundViewModel> roundViewModels = roundInfoModels.Select(roundInfoModel => new RoundViewModel
            {
                Player = new PlayerViewModel { Name = roundInfoModel.PlayerName, Type = roundInfoModel.PlayerType },
                Cards = roundInfoModel.Cards.Select(cardModel => new CardViewModel { Suit = cardModel.Suit, Rank = cardModel.Rank }).ToList(),
                State = roundInfoModel.RoundState,
                Score = CalculateCardScore(roundInfoModel.Cards)
            });

            return roundViewModels;
        }

        public void Step()
        {
            StepInfoModel stepInfoModel = _roundRepository.GetStepInfo(_user.Id, _game.Id);
            List<long> shuffledCards = GetShuffledCards(stepInfoModel.RoundsCards);

            var roundCard = new RoundCard { RoundId = stepInfoModel.UserRoundId, CardId = shuffledCards[0] };
            _roundCardRepository.Add(roundCard);
            if (!IsStepPossible())
            {
                EndRound();
            }
        }

        public void EndRound()
        {
            //CreateNonPlayableCards(rounds);

            List<RoundInfoModel> roundInfoModels = _roundRepository.GetLastRoundsInfo(_game.Id).ToList();
            UpdateRounds(roundInfoModels);
        }

        public void NextRound()
        {
            int lastRounds = _gameRepository.GetPlayerCount(_game.Id);
            CreateRound(lastRounds);
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

        private List<long> GetShuffledCards(List<Card> cards = null)
        {
            var cardIds = new List<long>();
            for (int i = 0; i < BlackJackConstants.DeckCount; i++)
            {
                IEnumerable<long> deck = Enumerable.Range(1, BlackJackConstants.DeckCapacity)
                    .Select(cardId => (long)cardId);
                cardIds.AddRange(deck);
            }

            if (cards != null)
            {
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
            var cardsCopy = new List<Card>(cards);
            int score = 0;
            foreach (var card in cardsCopy)
            {
                score += CardHelper.GetCardScore(card.Rank);
            }
            while (score > 21)
            {
                Card ace = cardsCopy.FirstOrDefault(card => card.Rank == Rank.Ace);
                if (ace == null)
                {
                    break;
                }
                cardsCopy.Remove(ace);
                score -= 10;
            }
            return score;
        }

        private void CreateNonPlayableCards(List<Round> rounds)
        {
            // TODO: some AI for bots and dealer
        }

        private void UpdateRounds(List<RoundInfoModel> roundInfoModels)
        {
            RoundInfoModel dealerRoundInfo = roundInfoModels
                .Where(roundInfo => roundInfo.PlayerType == PlayerType.Dealer)
                .First();
            roundInfoModels.Remove(dealerRoundInfo);

            foreach (var roundInfo in roundInfoModels)
            {
                int score = CalculateCardScore(roundInfo.Cards);
                if (score > 21)
                {
                    roundInfo.RoundState = RoundState.Lose;
                }
            }

            int dealerScore = CalculateCardScore(dealerRoundInfo.Cards);
            if (dealerScore > 21)
            {
                SetWinners(roundInfoModels);
            }
            if (dealerScore <= 21)
            {
                CheckStates(roundInfoModels, dealerScore);
            }
            _roundRepository.UpdateLastRoundInfo(roundInfoModels);
        }

        private void SetWinners(List<RoundInfoModel> roundInfoModels)
        {
            foreach (var roundInfo in roundInfoModels)
            {
                if (roundInfo.RoundState != RoundState.None)
                {
                    continue;
                }
                roundInfo.RoundState = RoundState.Won;
            }
        }

        private void CheckStates(List<RoundInfoModel> roundInfoModels, int dealerScore)
        {
            foreach (var roundInfo in roundInfoModels)
            {
                if (roundInfo.RoundState != RoundState.None)
                {
                    continue;
                }
                int score = CalculateCardScore(roundInfo.Cards);
                if (score > dealerScore)
                {
                    roundInfo.RoundState = RoundState.Won;
                }
                if (score == dealerScore)
                {
                    roundInfo.RoundState = RoundState.Push;
                }
                if (score < dealerScore)
                {
                    roundInfo.RoundState = RoundState.Lose;
                }
            }
        }

        private bool IsStepPossible()
        {
            List<Card> cards = _cardRepository.GetPlayerCards(_user.Id, _game.Id).ToList();
            int score = CalculateCardScore(cards);
            if (score >= 21)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
