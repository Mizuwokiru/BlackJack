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

        public CreateGameViewModel CreateGame(int playerId, int botCount)
        {
            Player playerFromDb = _playerRepository.Get(playerId);
            if (playerFromDb == null)
            {
                throw new InvalidOperationException($"Player with id {playerId} is not exists.");
            }
            IEnumerable<Player> botsFromDb = GetOrCreateBots(botCount);

            Game gameToDb = new Game();
            _gameRepository.Add(gameToDb);

            var bots = new List<PlayerViewModel>();
            var gamePlayers = new List<GamePlayer> { new GamePlayer { GameId = gameToDb.Id, PlayerId = playerFromDb.Id } };
            foreach (var botFromDb in botsFromDb)
            {
                bots.Add(new PlayerViewModel { Id = botFromDb.Id, Name = botFromDb.Name });
                gamePlayers.Add(new GamePlayer { GameId = gameToDb.Id, PlayerId = botFromDb.Id });
            }
            _gamePlayerRepository.Add(gamePlayers);

            CreateGameViewModel createdGame = new CreateGameViewModel
            {
                GameId = gameToDb.Id,
                Bots = bots
            };
            return createdGame;
        }

        private List<int> GetShuffledCardsIds()
        {
            var cards = new List<int>();
            for (int i = 0; i < Constants.DeckCount; i++)
            {
                cards.AddRange(Enumerable.Range(1, Constants.DeckCapacity));
            }

            var random = new Random();
            for (int i = cards.Count - 1, j; i >= 1; i--)
            {
                j = random.Next(i + 1);
                int tmp = cards[i];
                cards[i] = cards[j];
                cards[j] = tmp;
            }

            return cards;
        }

        private List<CardViewModel> GetStartCards(List<int> cardIds, int playerCount)
        {
            var cards = new List<CardViewModel>();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < playerCount; j++)
                {
                    var foundCard = _cardRepository.Cards.Where(card => cardIds[i * playerCount + j] == card.Id).FirstOrDefault();
                    cards.Add(new CardViewModel { Suit = foundCard.Suit.ToString(), Rank = foundCard.Rank.ToString() });
                }
            }
            cardIds.RemoveRange(0, playerCount * 2);
            return cards;
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

            var round = new RoundViewModel { Number = newRoundNumber, BotsCards = new List<PlayerCardsViewModel>() };
            IEnumerable<Player> playersOfGame = _playerRepository.GetPlayersByGamePlayers(_gamePlayerRepository.GetPlayersByGame(gameId));
            var roundPlayers = new List<RoundPlayer>();
            foreach (var playerOfGame in playersOfGame)
            {
                roundPlayers.Add(new RoundPlayer { PlayerId = playerOfGame.Id, RoundId = roundToDb.Id });
                if (playerOfGame.IsBot)
                {
                    round.BotsCards.Add(new PlayerCardsViewModel { PlayerId = playerOfGame.Id });
                    continue;
                }
                round.UserCards = new PlayerCardsViewModel { PlayerId = playerOfGame.Id };
            }
            _roundPlayerRepository.Add(roundPlayers);

            List<int> cards = GetShuffledCardsIds();

            round.UserCards.Cards = new List<CardViewModel>
            {
                new CardViewModel(), cacheModel.RemainingCards.Dequeue()
            };
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
            var roundId = (_cache.Get(gameId) as CachedRound).Round.Id;
            Round roundFromDb = _roundRepository.Get(roundId);
            if (roundFromDb == null)
            {
                throw new InvalidOperationException($"Round with id {roundId} is not exists.");
            }

            roundFromDb.IsFinished = true;
            _roundRepository.Update(roundFromDb);
            _cache.Remove(gameId);
        }

        private class CachedRound
        {
            public int RoundId { get; set; }

            public List<int> RemainingCardsIds { get; set; }

            public int DealerHiddenCard { get; set; }
        }
    }
}
