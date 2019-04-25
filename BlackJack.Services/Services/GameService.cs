using AutoMapper;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Helpers;
using BlackJack.ViewModels.Game;
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
        private readonly long _userId;

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
            string playerIdClaimValue = httpContextAccessor.HttpContext.User.FindFirst(Constants.ClaimPlayerId).Value;
            if (!string.IsNullOrEmpty(playerIdClaimValue))
            {
                _userId = long.Parse(playerIdClaimValue);
            }
        }

        public MenuViewModel GetMenu()
        {
            Game unfinishedGame = _gameRepository.GetUnfinishedGame(_userId);
            var menu = new MenuViewModel
            {
                HasUnfinishedGame = unfinishedGame != null,
                MaxBotCount = Constants.MaxBotCount
            };
            return menu;
        }

        public GameViewModel GetRoundInfo()
        {
            Game game = _gameRepository.GetUnfinishedGame(_userId);
            if (game == null)
            {
                throw new InvalidOperationException("Game is not found");
            }
            IEnumerable<RoundInfoModel> roundInfoModels = _roundRepository.GetLastRoundsInfo(game.Id);
            List<PlayerGameViewModel> players = Mapper.Map<IEnumerable<RoundInfoModel>, List<PlayerGameViewModel>>(roundInfoModels);
            if (players[0].State == RoundState.None)
            {
                PlayerGameViewModel dealer = players[players.Count - 1];
                dealer.Cards[1] = Constants.BlankCardCode;
                dealer.Score = 0;
            }
            var roundInfo = new GameViewModel { Players = players };
            return roundInfo;
        }

        public void NewGame(int neededBotCount)
        {
            EndGame();

            Game game = new Game();
            _gameRepository.Add(game);

            int availableBotCount = _playerRepository.GetBotCount();
            if (availableBotCount < neededBotCount)
            {
                CreateBots(availableBotCount, neededBotCount);
            }

            CreateRound(game, neededBotCount);
        }

        public void Step()
        {
            Game game = _gameRepository.GetUnfinishedGame(_userId);
            if (game == null)
            {
                throw new InvalidOperationException("Game is not found");
            }
            StepInfoModel stepInfoModel = _roundRepository.GetStepInfo(_userId, game.Id);
            if (stepInfoModel.UserState != RoundState.None)
            {
                throw new InvalidOperationException("Player can\'t to step when RoundState != None");
            }
            List<long> shuffledCards = GetShuffledCards(stepInfoModel.RoundsCards);
            var roundCard = new RoundCard { RoundId = stepInfoModel.UserRoundId, CardId = shuffledCards[0] };
            _roundCardRepository.Add(roundCard);
            if (!IsStepPossible(game))
            {
                Skip();
            }
        }

        public void Skip()
        {
            Game game = _gameRepository.GetUnfinishedGame(_userId);
            if (game == null)
            {
                throw new InvalidOperationException("Game is not found");
            }
            List<RoundInfoModel> roundInfoModels = _roundRepository.GetLastRoundsInfo(game.Id).ToList();
            if (roundInfoModels[0].State != RoundState.None)
            {
                throw new InvalidOperationException("Round already finished");
            }
            List<Card> allRoundCards = roundInfoModels.SelectMany(roundInfo => roundInfo.Cards).ToList();
            List<long> shuffledCards = GetShuffledCards(allRoundCards);
            var roundCards = new List<RoundCard>();
            foreach (var roundInfo in roundInfoModels)
            {
                IEnumerable<RoundCard> gotCards = DoPlayBot(roundInfo, shuffledCards);
                shuffledCards.RemoveRange(0, gotCards.Count());
                roundCards.AddRange(gotCards);
            }
            _roundCardRepository.Add(roundCards);
            UpdateRounds(roundInfoModels);
        }

        public void NextRound()
        {
            Game game = _gameRepository.GetUnfinishedGame(_userId);
            if (game == null)
            {
                throw new InvalidOperationException("Game is not found");
            }
            int lastRoundBotCount = _gameRepository.GetPlayerCount(game.Id) - 2;
            CreateRound(game, lastRoundBotCount);
        }

        public void EndGame()
        {
            Game unfinishedGame = _gameRepository.GetUnfinishedGame(_userId);
            if (unfinishedGame != null)
            {
                unfinishedGame.IsFinished = true;
                _gameRepository.Update(unfinishedGame);
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

        private void CreateRound(Game game, int neededBotCount)
        {
            IEnumerable<Player> bots = _playerRepository.GetBots(neededBotCount);

            Round userRound = new Round { GameId = game.Id, PlayerId = _userId };
            Round dealerRound = new Round { GameId = game.Id, PlayerId = Constants.DealerId };
            var rounds = new List<Round> { userRound, dealerRound };
            foreach (var bot in bots)
            {
                Round botRound = new Round { GameId = game.Id, PlayerId = bot.Id };
                rounds.Add(botRound);
            }
            _roundRepository.Add(rounds);

            CreateCards(rounds);

            if (!IsStepPossible(game))
            {
                Skip();
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

        private List<long> GetShuffledCards(IEnumerable<Card> cards = null)
        {
            var cardIds = Enumerable.Range(1, Constants.CardCount)
                    .Select(cardId => (long)cardId)
                    .ToList();

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

        private bool IsStepPossible(Game game)
        {
            List<Card> cards = _cardRepository.GetPlayerCards(_userId, game.Id).ToList();
            int score = CalculateCardScore(cards);
            if (score >= Constants.BlackJackValue)
            {
                return false;
            }
            return true;
        }

        internal static int CalculateCardScore(IEnumerable<Card> cards)
        {
            int score = 0;
            foreach (var card in cards)
            {
                score += CardHelper.GetCardValue(card.Rank);
            }
            if (score <= Constants.BlackJackValue)
            {
                return score;
            }
            int aceCount = cards.Count(card => card.Rank == Rank.Ace);
            while (score > Constants.BlackJackValue && aceCount > 0)
            {
                score -= CardHelper.GetCardValue(Rank.Ace) - Constants.AceSecondaryValue;
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
            while (score < Constants.DealerStopValue)
            {
                Tuple<Suit, Rank> cardData = CardHelper.GetCardById(shuffledCards[gotCardsCount]);
                Card card = new Card { Id = shuffledCards[gotCardsCount], Suit = cardData.Item1, Rank = cardData.Item2 };
                var roundCard = new RoundCard { CardId = card.Id, RoundId = roundInfo.RoundId };
                gotCardsCount++;
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
                if (score > Constants.BlackJackValue)
                {
                    roundInfo.State = RoundState.Lose;
                }
            }

            int dealerScore = CalculateCardScore(dealerRoundInfo.Cards);
            if (dealerScore > Constants.BlackJackValue)
            {
                SetWinners(roundInfoModels);
            }
            if (dealerScore <= Constants.BlackJackValue)
            {
                CheckStates(roundInfoModels, dealerScore);
            }
            _roundRepository.UpdateLastRoundInfo(roundInfoModels);
        }

        private void SetWinners(IEnumerable<RoundInfoModel> roundInfoModels)
        {
            foreach (var roundInfo in roundInfoModels)
            {
                if (roundInfo.State != RoundState.None)
                {
                    continue;
                }
                roundInfo.State = RoundState.Won;
            }
        }

        private void CheckStates(IEnumerable<RoundInfoModel> roundInfoModels, int dealerScore)
        {
            foreach (var roundInfo in roundInfoModels)
            {
                if (roundInfo.State != RoundState.None)
                {
                    continue;
                }
                int score = CalculateCardScore(roundInfo.Cards);
                if (score > dealerScore)
                {
                    roundInfo.State = RoundState.Won;
                }
                if (score == dealerScore)
                {
                    roundInfo.State = RoundState.Push;
                }
                if (score < dealerScore)
                {
                    roundInfo.State = RoundState.Lose;
                }
            }
        }
        #endregion
    }
}
