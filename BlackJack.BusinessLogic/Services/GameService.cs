using BlackJack.BusinessLogic.Exceptions;
using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : IGameService
    {
        private const int DealerId = 1;

        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IRoundCardRepository _roundCardRepository;
        private readonly IMemoryCache _cache;

        public GameService(IGameRepository gameRepository,
            IPlayerRepository playerRepository,
            IRoundRepository roundRepository,
            ICardRepository cardRepository,
            IRoundCardRepository roundCardRepository,
            IMemoryCache cache)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _roundRepository = roundRepository;
            _cardRepository = cardRepository;
            _roundCardRepository = roundCardRepository;
            _cache = cache;
        }

        public GameViewModel CreateGame(int playerId, int botCount)
        {
            Game game = _gameRepository.GetUnfinishedGame(playerId);
            if (game != null)
            {
                game.IsFinished = true;
                _gameRepository.Update(game);
            }
            if (botCount < 0 || botCount > Constants.MaxBotCount)
            {
                throw new ArgumentOutOfRangeException($"Bot count {botCount} is too much");
            }
            Player playerFromDb = _playerRepository.Get(playerId);
            List<Player> botsFromDb = _playerRepository.GetOrCreateBots(botCount).ToList();
            botsFromDb.Add(_playerRepository.Get(DealerId));

            game = new Game();
            _gameRepository.Add(game);

            var roundsToDb = new List<Round> { new Round { GameId = game.Id, PlayerId = playerId } };
            foreach (var botFromDb in botsFromDb)
            {
                roundsToDb.Add(new Round { GameId = game.Id, PlayerId = botFromDb.Id });
            }
            _roundRepository.Add(roundsToDb);

            var players = new List<PlayerViewModel>();
            foreach (var botFromDb in botsFromDb)
            {
                players.Add(new PlayerViewModel { PlayerId = botFromDb.Id, PlayerName = botFromDb.Name });
            }

            var createdGame = new GameViewModel { GameId = game.Id, Players = players };
            return createdGame;
        }

        public GameViewModel ContinueGame(int playerId)
        {
            Game game = _gameRepository.GetUnfinishedGame(playerId);
            if (game == null)
            {
                throw new RecordNotFoundException($"Unfinished games for player with {playerId} is not found");
            }
            return null; // TODO
        }

        public List<PlayerCardsViewModel> GetRound(int gameId)
        {
            List<Round> roundsFromDb = _roundRepository.GetLastRoundsByGame(gameId).ToList();

            List<int> shuffledCards = GetShuffledCards();
            List<RoundCard> roundCards = null;
            if (!_roundCardRepository.IsCardsHandedOut(roundsFromDb[0].Id))
            {
                roundCards = InitCards(roundsFromDb, shuffledCards);
            }
            if (roundCards == null)
            {
                roundCards = GetAvailableCards(roundsFromDb);
            }

            foreach (var roundCard in roundCards)
            {
                shuffledCards.Remove(roundCard.CardId);
            }

            var playerCards = new List<PlayerCardsViewModel>();
            foreach (var roundFromDb in roundsFromDb)
            {
                List<CardViewModel> cards = _cardRepository.GetCardsByRound(roundFromDb.Id)
                    .Select(card => new CardViewModel { Suit = card.Suit, Rank = card.Rank })
                    .ToList();
                playerCards.Add(new PlayerCardsViewModel { PlayerId = roundFromDb.PlayerId, PlayerCards = cards });
            }

            return playerCards;
        }

        #region Private methods
        private static List<int> GetShuffledCards()
        {
            var cards = new List<int>();
            for (int i = 0; i < Constants.DeckCount; i++)
            {
                cards.AddRange(Enumerable.Range(1, Constants.DeckCapacity));
            }

            var random = new Random();
            for (int i = cards.Count - 1, j; i > 0; i--)
            {
                j = random.Next(i + 1);
                int tmp = cards[i];
                cards[i] = cards[j];
                cards[j] = tmp;
            }

            return cards;
        }

        private List<RoundCard> InitCards(List<Round> rounds, List<int> shuffledCards)
        {
            var roundCardsToDb = new List<RoundCard>();
            for (int i = 0; i < rounds.Count; i++)
            {
                roundCardsToDb.Add(
                    new RoundCard { RoundId = rounds[i].Id, CardId = shuffledCards[i] });
                roundCardsToDb.Add(
                    new RoundCard { RoundId = rounds[i].Id, CardId = shuffledCards[i + rounds.Count] });
            }
            _roundCardRepository.Add(roundCardsToDb);
            return roundCardsToDb;
        }

        private List<RoundCard> GetAvailableCards(List<Round> rounds)
        {
            var availableCards = new List<RoundCard>();
            foreach (var round in rounds)
            {
                availableCards.AddRange(_roundCardRepository.GetCardsByRound(round.Id));
            }
            return availableCards;
        }

        #endregion
    }
}
