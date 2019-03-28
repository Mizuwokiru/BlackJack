using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IGamePlayerRepository _gamePlayerRepository;
        private readonly IRoundPlayerRepository _roundPlayerRepository;
        private readonly ICardRepository _cardRepository;

        private readonly IMemoryCache _cache;

        public GameService(IGameRepository gameRepository,
            IRoundRepository roundRepository,
            IPlayerRepository playerRepository,
            IGamePlayerRepository gamePlayerRepository,
            IRoundPlayerRepository roundPlayerRepository,
            ICardRepository cardRepository,
            IMemoryCache cache)
        {
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _playerRepository = playerRepository;
            _gamePlayerRepository = gamePlayerRepository;
            _roundPlayerRepository = roundPlayerRepository;
            _cardRepository = cardRepository;
            _cache = cache;
        }

        private IEnumerable<Player> GetOrCreateBots(int botCount)
        {
            if (botCount < 0 || botCount > Constants.MaxBotCount)
            {
                throw new ValidationException("Bot count is invalid!");
            }
            return _playerRepository.GetOrCreateBots(botCount);
        }

        public int CreateGame(int playerId, int botCount)
        {
            Player playerFromDb = _playerRepository.Get(playerId);
            if (playerFromDb == null)
            {
                throw new InvalidOperationException($"Player with id {playerId} is not exists.");
            }
            var bots = GetOrCreateBots(botCount);

            var gameToDb = new Game();
            _gameRepository.Add(gameToDb);

            _gamePlayerRepository.Add(new GamePlayer { GameId = gameToDb.Id, PlayerId = playerFromDb.Id });
            foreach (var bot in bots)
            {
                _gamePlayerRepository.Add(new GamePlayer { GameId = gameToDb.Id, PlayerId = bot.Id });
            }

            return gameToDb.Id;
        }

        public RoundViewModel CreateRound(int gameId)
        {
            Game gameFromDb = _gameRepository.Get(gameId);
            if (gameFromDb == null)
            {
                throw new InvalidOperationException($"Game with id {gameId} is not exists.");
            }
            int newRoundNumber = _roundRepository.GetRoundsByGame(gameId).Count() + 1;
            var roundToDb = new Round { GameId = gameId, Number = newRoundNumber };
            _roundRepository.Add(roundToDb);

            var round = new RoundViewModel { Id = roundToDb.Id, Number = newRoundNumber, BotsCards = new List<PlayerCardsViewModel>() };

            IEnumerable<Player> playersOfGame = _playerRepository.GetPlayersByGamePlayers(_gamePlayerRepository.GetPlayersByGame(gameId));
            //IEnumerable<Player> playersOfGame = _gamePlayerRepository.GetPlayersByGame(gameId).Select(gamePlayer => gamePlayer.Player);
            foreach (var playerOfGame in playersOfGame)
            {
                var roundPlayer = new RoundPlayer { PlayerId = playerOfGame.Id, RoundId = roundToDb.Id };
                _roundPlayerRepository.Add(roundPlayer);
                var playerViewModel = new PlayerViewModel { Id = roundPlayer.Id, Name = playerOfGame.Name };
                if (playerOfGame.IsBot)
                {
                    round.BotsCards.Add(new PlayerCardsViewModel { Player = playerViewModel });
                    continue;
                }
                round.UserCards = new PlayerCardsViewModel { Player = playerViewModel };
            }

            var cacheModel = new CacheRoundModel { RemainingCards = GetShuffledCards() };

            round.UserCards.Cards = new List<CardViewModel> { cacheModel.RemainingCards.Dequeue(), cacheModel.RemainingCards.Dequeue() };
            foreach (var playerCardsModel in round.BotsCards)
            {
                playerCardsModel.Cards = new List<CardViewModel> { cacheModel.RemainingCards.Dequeue(), cacheModel.RemainingCards.Dequeue() };
            }
            round.DealerCards = new List<CardViewModel> { cacheModel.RemainingCards.Dequeue() };

            cacheModel.Round = round;
            cacheModel.DealerHiddenCard = cacheModel.RemainingCards.Dequeue();
            _cache.Set(gameId, cacheModel);

            return round;
        }

        public void FinishRound(int gameId)
        {
            var roundId = (_cache.Get(gameId) as CacheRoundModel).Round.Id;
            Round roundFromDb = _roundRepository.Get(roundId);
            if (roundFromDb == null)
            {
                throw new InvalidOperationException($"Round with id {roundId} is not exists.");
            }

            roundFromDb.IsFinished = true;
            _roundRepository.Update(roundFromDb);
            _cache.Remove(gameId);
        }

        private Queue<CardViewModel> GetShuffledCards()
        {
            var cardsFromDb = _cardRepository.GetAll().ToList();
            if (cardsFromDb.Count < Constants.DeckCapacity)
            {
                throw new ValidationException("Cards is not enough.");
            }

            var unshuffledCards = new List<CardViewModel>();
            foreach (var cardFromDb in cardsFromDb)
            {
                var card = new CardViewModel { Rank = cardFromDb.Rank.ToString(), Suit = cardFromDb.Suit.ToString() };
                for (int i = 0; i < Constants.DeckCount; i++)
                {
                    unshuffledCards.Add(card);
                }
            }

            var cardIndexSequence = Enumerable.Range(0, Constants.GameCardCount).ToList();
            var random = new Random();
            var shuffledCards = new Queue<CardViewModel>();
            for (int i = 0; i < Constants.GameCardCount; i++)
            {
                var randIndex = random.Next(cardIndexSequence.Count);
                shuffledCards.Enqueue(unshuffledCards[cardIndexSequence[randIndex]]);
                cardIndexSequence.RemoveAt(randIndex);
            }

            return shuffledCards;
        }

        private class CacheRoundModel
        {
            public RoundViewModel Round { get; set; }

            public Queue<CardViewModel> RemainingCards { get; set; }

            public CardViewModel DealerHiddenCard { get; set; }
        }
    }
}
