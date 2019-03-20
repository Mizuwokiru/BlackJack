using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Models;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;

namespace BlackJack.BusinessLogic.Services
{
    public class GameCreationService : IGameCreationService
    {
        private const int MaxBotCount = 7;

        private IPlayerRepository _playerRepository;
        private IGameRepository _gameRepository;
        private IGamePlayerRepository _gamePlayerRepository;

        public GameCreationService(IPlayerRepository playerRepository,
            IGameRepository gameRepository,
            IGamePlayerRepository gamePlayerRepository)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
            _gamePlayerRepository = gamePlayerRepository;
        }

        public IEnumerable<PlayerModel> GetPlayables()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Player, PlayerModel>()).CreateMapper();
            return mapper.Map<IEnumerable<Player>, List<PlayerModel>>(_playerRepository.GetPlayables());
        }

        #region Privates for MakeGame
        private Player GetOrMakePlayer(string playerName)
        {
            Player player = _playerRepository.Find(p => p.Name.Equals(playerName)).FirstOrDefault();
            return (player == null) ? new Player { Name = playerName } : player;
        }

        private IEnumerable<Player> GetOrMakeBots(int botCount)
        {
            List<Player> bots = _playerRepository.GetBots().ToList();
            if (bots.Count < botCount)
            {
                for (int i = bots.Count; i < botCount; i++)
                {
                    _playerRepository.Create(new Player { Name = $"Bot #{i + 1}", IsBot = true });
                }
            }
            return bots;
        }
        #endregion

        public int MakeGame(string playerName, int botCount)
        {
            if (botCount > MaxBotCount)
            {
                throw new ArgumentOutOfRangeException("Слишком много ботов.");
            }

            Player player = GetOrMakePlayer(playerName);
            _playerRepository.Create(player);

            IEnumerable<Player> bots = GetOrMakeBots(botCount);

            var game = new Game();
            _gameRepository.Create(game);

            _gamePlayerRepository.Create(new GamePlayer { Game = game, Player = player });
            foreach (var bot in bots)
            {
                _gamePlayerRepository.Create(new GamePlayer { Game = game, Player = bot });
            }

            return game.Id;
        }
    }
}
