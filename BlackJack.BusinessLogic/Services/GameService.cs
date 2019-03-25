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
        private IBotRepository _botRepository;
        private IGameRepository _gameRepository;
        private IRoundRepository _roundRepository;
        private IUserRepository _userRepository;

        public GameService(IBotRepository botRepository,
            IGameRepository gameRepository,
            IRoundRepository roundRepository,
            IUserRepository userRepository)
        {
            _botRepository = botRepository;
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<BotModel> CreateBots(int botCount)
        {
            if (botCount < 0 || botCount > Constants.MaxBotCount)
            {
                throw new ValidationException("Bot count is invalid!");
            }
            IEnumerable<Bot> botsFromDb = _botRepository.GetOrCreateBots(botCount);
            var bots = new List<BotModel>();
            foreach (var botFromDb in botsFromDb)
            {
                bots.Add(new BotModel { Id = botFromDb.Id, Name = botFromDb.Name });
            }
            return bots;
        }

        public GameModel CreateGame(int userId)
        {
            var userFromDb = _userRepository.Get(userId);
            if (userFromDb == null)
            {
                throw new InvalidOperationException($"User with id {userId} is not exists.");
            }
            var gameToDb = new Game { User = userFromDb };
            _gameRepository.Add(gameToDb);
            return new GameModel { Id = gameToDb.Id, UserId = userId };
        }

        public RoundModel CreateRound(int gameId)
        {
            var gameFromDb = _gameRepository.Get(gameId);
            if (gameFromDb == null)
            {
                throw new InvalidOperationException($"Game with id {gameId} is not exists.");
            }
            int roundCount = _roundRepository.GetAll().Count();
            var roundToDb = new Round { Game = gameFromDb, Number = roundCount };
            _roundRepository.Add(roundToDb);
            return new RoundModel { Id = roundToDb.Id, Number = roundToDb.Number };
        }


    }
}
