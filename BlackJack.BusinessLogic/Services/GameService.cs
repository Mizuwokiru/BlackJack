using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared;
using BlackJack.Shared.Enums;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public CreateGameViewModel CreateGame(int playerId, int botCount) // TODO: add ContinueGame
        {
            if (botCount < 0 || botCount > Constants.MaxBotCount)
            {
                throw new Exception(); // TODO
            }
            Player playerFromDb = _playerRepository.Get(playerId);
            if (playerFromDb == null || !playerFromDb.IsPlayable) // remove it after identity support added
            {
                throw new Exception(); // TODO
            }
            IEnumerable<Player> botsFromDb = _playerRepository.GetOrCreateBots(botCount);
            Player dealerFromDb = _playerRepository.Get(DealerId);

            var gameToDb = new Game();
            _gameRepository.Add(gameToDb);

            var players = new List<PlayerViewModel>();
            foreach (var botFromDb in botsFromDb)
            {
                players.Add(new PlayerViewModel { PlayerId = botFromDb.Id, PlayerName = botFromDb.Name });
            }
            players.Add(new PlayerViewModel { PlayerId = dealerFromDb.Id, PlayerName = dealerFromDb.Name });

            List<int> shuffledCards = GetShuffledCards();

            var roundsToDb = new List<Round> { new Round { GameId = gameToDb.Id, PlayerId = playerId } };
            foreach (var player in players)
            {
                roundsToDb.Add(new Round { GameId = gameToDb.Id, PlayerId = player.PlayerId });
            }
            _roundRepository.Add(roundsToDb);

            var roundCardsToDb = new List<RoundCard>();
            for (int i = 0; i < roundsToDb.Count; i++)
            {
                roundCardsToDb.Add(
                    new RoundCard { RoundId = roundsToDb[i].Id, CardId = shuffledCards[i] });
                roundCardsToDb.Add(
                    new RoundCard { RoundId = roundsToDb[i].Id, CardId = shuffledCards[i + roundsToDb.Count] });
            }
            _roundCardRepository.Add(roundCardsToDb);
            shuffledCards.RemoveRange(0, roundsToDb.Count * 2);

            _cache.Set(gameToDb.Id, shuffledCards, TimeSpan.FromMinutes(10));

            var createdGame = new CreateGameViewModel { GameId = gameToDb.Id, Players = players };
            return createdGame;
        }

        public List<PlayerCardsViewModel> GetRound(int gameId)
        {
            IEnumerable<Round> roundsFromDb = _roundRepository.GetLastRoundsByGame(gameId);

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

        //private CardViewModel AddRoundPlayerCard(int roundPlayerId, int cardId, List<RoundPlayerCard> roundPlayerCardsToDb)
        //{
        //    var roundPlayerCard = new RoundPlayerCard { RoundPlayerId = roundPlayerId, CardId = cardId };
        //    roundPlayerCardsToDb.Add(roundPlayerCard);
        //    Card card = roundPlayerCard.Card;
        //    return new CardViewModel { Suit = card.Suit.ToString(), Rank = card.Rank.ToString() };
        //}
        #endregion
    }
}
