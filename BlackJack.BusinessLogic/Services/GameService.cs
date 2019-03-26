using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared;
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

        public GameService(IGameRepository gameRepository,
            IRoundRepository roundRepository,
            IPlayerRepository playerRepository,
            IGamePlayerRepository gamePlayerRepository,
            IRoundPlayerRepository roundPlayerRepository)
        {
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _playerRepository = playerRepository;
            _gamePlayerRepository = gamePlayerRepository;
            _roundPlayerRepository = roundPlayerRepository;
        }

        private IEnumerable<Player> GetOrCreateBots(int botCount)
        {
            if (botCount < 0 || botCount > Constants.MaxBotCount)
            {
                throw new ValidationException("Bot count is invalid!");
            }
            IEnumerable<Player> botsFromDb = _playerRepository.GetOrCreateBots(botCount);
            
            //var bots = new List<PlayerModel>();
            //foreach (var botFromDb in botsFromDb)
            //{
            //    bots.Add(new PlayerModel { Id = botFromDb.Id, Name = botFromDb.Name, IsBot = true });
            //}
            return botsFromDb;
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

            _gamePlayerRepository.Add(new GamePlayer { Game = gameToDb, Player = playerFromDb });
            foreach (var bot in bots)
            {
                _gamePlayerRepository.Add(new GamePlayer { Game = gameToDb, Player = playerFromDb });
            }

            return gameToDb.Id;
        }

        public int CreateRound(int gameId)
        {
            Game gameFromDb = _gameRepository.Get(gameId);
            if (gameFromDb == null)
            {
                throw new InvalidOperationException($"Game with id {gameId} is not exists.");
            }
            int roundCount = _roundRepository.GetRoundsByGame(gameId).Count();
            var roundToDb = new Round { Game = gameFromDb, Number = roundCount };
            _roundRepository.Add(roundToDb);

            IEnumerable<Player> playersOfGame = _gamePlayerRepository.GetPlayersByGame(gameId).Select(gamePlayer => gamePlayer.Player);
            foreach (var playerOfGame in playersOfGame)
            {
                _roundPlayerRepository.Add(new RoundPlayer { Player = playerOfGame, Round = roundToDb });
            }
            
            return roundToDb.Id;
        }

        public void FinishRound(int roundId)
        {
            Round roundFromDb = _roundRepository.Get(roundId);
            if (roundFromDb == null)
            {
                throw new InvalidOperationException($"Round with id {roundId} is not exists.");
            }

            roundFromDb.IsFinished = true;
            _roundRepository.Update(roundFromDb);
        }
    }
}
