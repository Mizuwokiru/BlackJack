using AutoMapper;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
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
        private readonly IRoundPlayerRepository _roundPlayerRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IRoundPlayerCardRepository _roundPlayerCardRepository;
        private readonly long _userId;

        public GameService(IGameRepository gameRepository,
            IPlayerRepository playerRepository,
            IRoundPlayerRepository roundRepository,
            ICardRepository cardRepository,
            IRoundPlayerCardRepository roundCardRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _roundPlayerRepository = roundRepository;
            _cardRepository = cardRepository;
            _roundPlayerCardRepository = roundCardRepository;
            string playerIdClaimValue = httpContextAccessor.HttpContext.User.FindFirst(Constants.ClaimPlayerId).Value;
            if (!string.IsNullOrEmpty(playerIdClaimValue))
            {
                _userId = long.Parse(playerIdClaimValue);
            }
        }

        public MenuViewModel GetMenu()
        {
            Game continueableGame = _gameRepository.GetContinueableGame(_userId);
            var menu = new MenuViewModel
            {
                HasUnfinishedGame = continueableGame != null,
                MaxBotCount = Constants.MaxBotCount
            };
            return menu;
        }

        public GameViewModel GetLastRoundInfo()
        {
            Game game = _gameRepository.GetContinueableGame(_userId);
            if (game == null)
            {
                throw new InvalidOperationException("Game is not found");
            }
            List<RoundPlayer> lastRoundInfo = _roundPlayerRepository.GetLastRoundInfo(game.Id).ToList();
            List<PlayerGameViewModel> players = Mapper.Map<List<RoundPlayer>, List<PlayerGameViewModel>>(lastRoundInfo);
            if (players[0].State == RoundPlayerState.None)
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
            Game game = _gameRepository.GetContinueableGame(_userId);
            if (game == null)
            {
                throw new InvalidOperationException("Game is not found");
            }
            RoundPlayer user = _roundPlayerRepository.GetLastRoundPlayerInfo(game.Id, _userId);
            List<Card> roundCards = _cardRepository.GetLastRoundCards(game.Id).ToList();
            if (user.State != RoundPlayerState.None)
            {
                throw new InvalidOperationException("Player can\'t to step when RoundState != None");
            }
            List<long> shuffledCards = GetShuffledCards(roundCards);
            var roundPlayerCard = new RoundPlayerCard { RoundPlayerId = user.Id, CardId = shuffledCards[0] };
            _roundPlayerCardRepository.Add(roundPlayerCard);
            if (!IsStepPossible(game))
            {
                Skip();
            }
        }

        public void Skip()
        {
            Game game = _gameRepository.GetContinueableGame(_userId);
            if (game == null)
            {
                throw new InvalidOperationException("Game is not found");
            }
            List<RoundPlayer> lastRoundInfo = _roundPlayerRepository.GetLastRoundInfo(game.Id).ToList();
            if (lastRoundInfo[0].State != RoundPlayerState.None)
            {
                throw new InvalidOperationException("Round already finished");
            }
            
            List<Card> allRoundCards = lastRoundInfo
                .SelectMany(roundPlayer => roundPlayer.Cards.Select(roundPlayerCard => roundPlayerCard.Card))
                .ToList();
            List<long> shuffledCards = GetShuffledCards(allRoundCards);
            var roundPlayerCards = new List<RoundPlayerCard>();
            foreach (var roundInfo in lastRoundInfo)
            {
                List<RoundPlayerCard> gotCards = DoPlayBot(roundInfo, shuffledCards);
                shuffledCards.RemoveRange(0, gotCards.Count);
                roundPlayerCards.AddRange(gotCards);
            }
            _roundPlayerCardRepository.Add(roundPlayerCards);
            UpdateRounds(lastRoundInfo);
        }

        public void NextRound()
        {
            Game game = _gameRepository.GetContinueableGame(_userId);
            if (game == null)
            {
                throw new InvalidOperationException("Game is not found");
            }
            int lastRoundBotCount = _gameRepository.GetBotCount(game.Id);
            CreateRound(game, lastRoundBotCount);
        }

        public void EndGame()
        {
            Game continueableGame = _gameRepository.GetContinueableGame(_userId);
            if (continueableGame != null)
            {
                continueableGame.IsFinished = true;
                _gameRepository.Update(continueableGame);
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

            RoundPlayer user = new RoundPlayer { GameId = game.Id, PlayerId = _userId };
            var roundPlayers = new List<RoundPlayer> { user };
            foreach (var bot in bots)
            {
                RoundPlayer botRound = new RoundPlayer { GameId = game.Id, PlayerId = bot.Id };
                roundPlayers.Add(botRound);
            }
            RoundPlayer dealer = new RoundPlayer { GameId = game.Id, PlayerId = Constants.DealerId };
            roundPlayers.Add(dealer);
            _roundPlayerRepository.Add(roundPlayers);

            CreateCards(roundPlayers);

            if (!IsStepPossible(game))
            {
                Skip();
            }
        }

        private void CreateCards(List<RoundPlayer> roundPlayers)
        {
            var roundPlayerCards = new List<RoundPlayerCard>();
            var shuffledCards = GetShuffledCards();
            for (int i = 0; i < roundPlayers.Count; i++)
            {
                var firstCard = new RoundPlayerCard { RoundPlayerId = roundPlayers[i].Id, CardId = shuffledCards[i] };
                var secondCard = new RoundPlayerCard { RoundPlayerId = roundPlayers[i].Id, CardId = shuffledCards[i + roundPlayers.Count] };
                roundPlayerCards.AddRange(new[] { firstCard, secondCard });
            }
            _roundPlayerCardRepository.Add(roundPlayerCards);
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
            List<Card> cards = _cardRepository.GetLastRoundPlayerCards(_userId, game.Id).ToList();
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
                score += card.Rank.GetValue();
            }
            if (score <= Constants.BlackJackValue)
            {
                return score;
            }
            int aceCount = cards.Count(card => card.Rank == Rank.Ace);
            while (score > Constants.BlackJackValue && aceCount > 0)
            {
                score -= Rank.Ace.GetValue() - Constants.AceSecondaryValue;
                aceCount--;
            }
            return score;
        }

        private List<RoundPlayerCard> DoPlayBot(RoundPlayer roundPlayer, List<long> shuffledCards)
        {
            if (roundPlayer.Player.Type == PlayerType.User)
            {
                return Enumerable.Empty<RoundPlayerCard>().ToList();
            }
            var roundCards = new List<RoundPlayerCard>();
            int gotCardsCount = 0;
            int score = CalculateCardScore(roundPlayer.Cards.Select(roundPlayerCard => roundPlayerCard.Card));
            while (score < Constants.DealerStopValue)
            {
                Card card = GetCardById(shuffledCards[gotCardsCount]);
                var roundCard = new RoundPlayerCard { CardId = card.Id, RoundPlayerId = roundPlayer.Id };
                gotCardsCount++;
                roundCards.Add(roundCard);
                roundPlayer.Cards.Add(roundCard);
                score = CalculateCardScore(roundPlayer.Cards.Select(roundPlayerCard => GetCardById(roundPlayerCard.CardId)));
            }
            return roundCards;
        }

        private void UpdateRounds(List<RoundPlayer> roundPlayers)
        {
            RoundPlayer dealer = roundPlayers
                .Where(roundPlayer => roundPlayer.Player.Type == PlayerType.Dealer)
                .First();
            roundPlayers.Remove(dealer);

            foreach (var roundPlayer in roundPlayers)
            {
                int score = CalculateCardScore(roundPlayer.Cards.Select(roundPlayerCard => GetCardById(roundPlayerCard.CardId)));
                if (score > Constants.BlackJackValue)
                {
                    roundPlayer.State = RoundPlayerState.Lose;
                }
            }

            int dealerScore = CalculateCardScore(dealer.Cards.Select(roundPlayerCard => GetCardById(roundPlayerCard.CardId)));
            if (dealerScore > Constants.BlackJackValue)
            {
                SetWinners(roundPlayers);
            }
            if (dealerScore <= Constants.BlackJackValue)
            {
                CheckStates(roundPlayers, dealerScore);
            }
            _roundPlayerRepository.Update(roundPlayers);
        }

        private void SetWinners(IEnumerable<RoundPlayer> roundPlayers)
        {
            foreach (var roundInfo in roundPlayers)
            {
                if (roundInfo.State != RoundPlayerState.None)
                {
                    continue;
                }
                roundInfo.State = RoundPlayerState.Won;
            }
        }

        private void CheckStates(IEnumerable<RoundPlayer> roundPlayers, int dealerScore)
        {
            foreach (var roundPlayer in roundPlayers)
            {
                if (roundPlayer.State != RoundPlayerState.None)
                {
                    continue;
                }
                int score = CalculateCardScore(roundPlayer.Cards.Select(roundPlayerCard => GetCardById(roundPlayerCard.CardId)));
                if (score > dealerScore)
                {
                    roundPlayer.State = RoundPlayerState.Won;
                }
                if (score == dealerScore)
                {
                    roundPlayer.State = RoundPlayerState.Draw;
                }
                if (score < dealerScore)
                {
                    roundPlayer.State = RoundPlayerState.Lose;
                }
            }
        }

        private Card GetCardById(long id)
        {
            Tuple<Suit, Rank> cardData = CardHelper.GetCardById(id);
            Card card = new Card { Id = id, Suit = cardData.Item1, Rank = cardData.Item2 };
            return card;
        }
        #endregion
    }
}
