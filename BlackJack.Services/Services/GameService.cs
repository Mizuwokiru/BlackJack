using AutoMapper;
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
        private Game _currentGame;

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
            _currentGame = _gameRepository.GetUnfinishedGame(_user.Id);
        }

        public bool HasUnfinishedGame()
        {
            return _currentGame != null;
        }

        public void NewGame(int neededBotCount)
        {
            EndGame();

            Game newGame = new Game();
            _gameRepository.Add(newGame);

            _currentGame = newGame;

            int availableBotCount = _playerRepository.GetBotCount();
            if (availableBotCount < neededBotCount)
            {
                CreateBots(availableBotCount, neededBotCount);
            }

            CreateRound(neededBotCount);
        }

        public IEnumerable<RoundViewModel> GetRoundsInfo()
        {
            IEnumerable<RoundInfoModel> roundInfoModels = _roundRepository.GetLastRoundsInfo(_currentGame.Id);
            IEnumerable<RoundViewModel> roundViewModels = Mapper.Map<IEnumerable<RoundInfoModel>, IEnumerable<RoundViewModel>>(roundInfoModels);
            return roundViewModels;
        }

        public void Step()
        {
            StepInfoModel stepInfoModel = _roundRepository.GetStepInfo(_user.Id, _currentGame.Id);
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
            List<RoundInfoModel> roundInfoModels = _roundRepository.GetLastRoundsInfo(_currentGame.Id).ToList();
            List<Card> allRoundCards = roundInfoModels.SelectMany(roundInfo => roundInfo.Cards).ToList();
            List<long> shuffledCards = GetShuffledCards(allRoundCards);
            var roundCards = new List<RoundCard>();
            foreach (var roundInfo in roundInfoModels)
            {
                IEnumerable<RoundCard> gotCards = DoPlayBot(roundInfo, shuffledCards);
                roundCards.AddRange(gotCards);
            }
            _roundCardRepository.Add(roundCards);
            UpdateRounds(roundInfoModels);
        }

        public void NextRound()
        {
            int lastRounds = _gameRepository.GetPlayerCount(_currentGame.Id);
            CreateRound(lastRounds);
        }

        public void EndGame()
        {
            if (_currentGame != null)
            {
                _currentGame.IsFinished = true;
                _gameRepository.Update(_currentGame);
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

            Round userRound = new Round { GameId = _currentGame.Id, PlayerId = _user.Id };
            Round dealerRound = new Round { GameId = _currentGame.Id, PlayerId = BlackJackConstants.DealerId };
            var rounds = new List<Round> { userRound, dealerRound };
            foreach (var bot in bots)
            {
                Round botRound = new Round { GameId = _currentGame.Id, PlayerId = bot.Id };
                rounds.Add(botRound);
            }
            _roundRepository.Add(rounds);

            CreateCards(rounds);

            if (!IsStepPossible())
            {
                EndRound();
            }
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

        internal static int CalculateCardScore(List<Card> cards)
        {
            int score = 0;
            foreach (var card in cards)
            {
                score += CardHelper.GetCardScore(card.Rank);
            }
            if (score <= BlackJackConstants.BlackJack)
            {
                return score;
            }
            int aceCount = cards.Count(card => card.Rank == Rank.Ace);
            while (score > BlackJackConstants.BlackJack && aceCount > 0)
            {
                score -= (int)Rank.Ace - BlackJackConstants.AceSecondaryValue;
                aceCount--;
            }
            return score;
        }

        private IEnumerable<RoundCard> DoPlayBot(RoundInfoModel roundInfo, List<long> shuffledCards)
        {
            if (roundInfo.PlayerType == PlayerType.User)
            {
                return Enumerable.Empty<RoundCard>();
            }
            var roundCards = new List<RoundCard>();
            int gotCardsCount = 0;
            int score = CalculateCardScore(roundInfo.Cards);
            while (score < BlackJackConstants.DealerStopValue)
            {
                Card card = _cardRepository.Get(shuffledCards[gotCardsCount]);
                gotCardsCount++;
                var roundCard = new RoundCard { CardId = card.Id, RoundId = roundInfo.RoundId };
                roundCards.Add(roundCard);
                roundInfo.Cards.Add(card);
                score = CalculateCardScore(roundInfo.Cards);
            }
            return roundCards;
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
                if (score > BlackJackConstants.BlackJack)
                {
                    roundInfo.RoundState = RoundState.Lose;
                }
            }

            int dealerScore = CalculateCardScore(dealerRoundInfo.Cards);
            if (dealerScore > BlackJackConstants.BlackJack)
            {
                SetWinners(roundInfoModels);
            }
            if (dealerScore <= BlackJackConstants.BlackJack)
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
            List<Card> cards = _cardRepository.GetPlayerCards(_user.Id, _currentGame.Id).ToList();
            int score = CalculateCardScore(cards);
            if (score >= BlackJackConstants.BlackJack)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
