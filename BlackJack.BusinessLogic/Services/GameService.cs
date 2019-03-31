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
        private readonly IGamePlayerRepository _gamePlayerRepository;
        private readonly IStepRepository _roundRepository;
        private readonly IStepCardRepository _roundCardRepository;

        public GameService(IGameRepository gameRepository,
            IPlayerRepository playerRepository,
            IGamePlayerRepository gamePlayerRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _gamePlayerRepository = gamePlayerRepository;
        }

        public int CreateGame(int playerId, int botCount)
        {
            if (botCount < 0 || botCount > Constants.MaxBotCount)
            {
                throw new Exception(); // TODO
            }
            Player playerFromDb = _playerRepository.Get(playerId);
            if (playerFromDb == null || playerFromDb.IsBot) // remove it after identity support added
            {
                throw new Exception(); // TODO
            }

            var gameToDb = new Game { State = GameState.OnlyCreated };
            _gameRepository.Add(gameToDb);

            IEnumerable<Player> botsFromDb = _playerRepository.GetOrCreateBots(botCount);
            var gamePlayers = new List<GamePlayer> { new GamePlayer { GameId = gameToDb.Id, PlayerId = playerId } };
            foreach (var botFromDb in botsFromDb)
            {
                gamePlayers.Add(new GamePlayer { GameId = gameToDb.Id, PlayerId = botFromDb.Id });
            }
            gamePlayers.Add(new GamePlayer { GameId = gameToDb.Id, PlayerId = DealerId });
            _gamePlayerRepository.Add(gamePlayers);

            return gameToDb.Id;
        }

        //public List<CardViewModel> CreateRound(int gameId)
        //{
        //    Game gameFromDb = _gameRepository.Get(gameId);
        //    if (gameFromDb == null)
        //    {
        //        throw new Exception();
        //    }

        //    int roundNumber = _roundRepository.GetRoundCount();
        //    var round = new Step
        //    {
        //        GameId = gameFromDb.Id,
        //        Number = roundNumber
        //    };
        //    _roundRepository.Add(round);

        //    List<int> shuffledCards = GetShuffledCards();

        //    List<Player> playersFromDb = _playerRepository.GetPlayers(gameId).ToList();
        //    var roundPlayersToDb = new List<RoundPlayer>();
        //    foreach (var playerFromDb in playersFromDb)
        //    {
        //        var roundPlayerToDb = new RoundPlayer { RoundId = round.Id, PlayerId = playerFromDb.Id };
        //        roundPlayersToDb.Add(roundPlayerToDb);
        //    }
        //    _roundPlayerRepository.Add(roundPlayersToDb);

        //    var roundPlayerCardsToDb = new List<RoundPlayerCard>();
        //    var cardViewModels = new List<CardViewModel>();
        //    for (int i = 0; i < roundPlayersToDb.Count; i++)
        //    {
        //        CardViewModel cardViewModel = 
        //            AddRoundPlayerCard(roundPlayersToDb[i].Id, shuffledCards[i + roundPlayersToDb.Count + 1], roundPlayerCardsToDb);
        //    }
        //}

        //#region Private methods
        //private static List<int> GetShuffledCards()
        //{
        //    var cards = new List<int>();
        //    for (int i = 0; i < Constants.DeckCount; i++)
        //    {
        //        cards.AddRange(Enumerable.Range(1, Constants.DeckCapacity));
        //    }

        //    var random = new Random();
        //    for (int i = cards.Count - 1, j; i > 0; i--)
        //    {
        //        j = random.Next(i + 1);
        //        int tmp = cards[i];
        //        cards[i] = cards[j];
        //        cards[j] = tmp;
        //    }

        //    return cards;
        //}

        //private CardViewModel AddRoundPlayerCard(int roundPlayerId, int cardId, List<RoundPlayerCard> roundPlayerCardsToDb)
        //{
        //    var roundPlayerCard = new RoundPlayerCard { RoundPlayerId = roundPlayerId, CardId = cardId };
        //    roundPlayerCardsToDb.Add(roundPlayerCard);
        //    Card card = roundPlayerCard.Card;
        //    return new CardViewModel { Suit = card.Suit.ToString(), Rank = card.Rank.ToString() };
        //}
        //#endregion
    }
}
