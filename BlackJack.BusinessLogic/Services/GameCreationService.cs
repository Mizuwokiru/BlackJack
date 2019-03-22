using System.Collections.Generic;
using System.Text.RegularExpressions;
using BlackJack.BusinessLogic.Exceptions;
using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.BusinessLogic.Utils;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared;

namespace BlackJack.BusinessLogic.Services
{
    public class GameCreationService : IGameCreationService
    {
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

        public IEnumerable<PlayerViewModel> GetPlayables()
        {
            return Mapper.MapPlayers(_playerRepository.GetAll());
            //return Mapper.MapPlayers(_playerRepository.GetPlayers());
        }

        public GameCreationViewModel CreateGame(string playerName, int botCount)
        {
            if (botCount > Constants.MaxBotCount)
            {
                throw new ValidationException("Too many bots.", botCount.ToString());
            }
            if (!Regex.IsMatch(playerName, @"^[a-zA-Z][a-zA-Z0-9]{5,}$"))
            {
                throw new ValidationException("Invalid player name.", playerName);
            }

            Player player = _playerRepository.GetOrCreatePlayer(playerName);
            IEnumerable<Player> bots = _playerRepository.GetOrCreateBots(botCount);

            var game = new Game();
            _gameRepository.Create(game);

            _gamePlayerRepository.Create(new GamePlayer { Game = game, Player = player });
            foreach (var bot in bots)
            {
                _gamePlayerRepository.Create(new GamePlayer { Game = game, Player = bot });
            }

            return new GameCreationViewModel { PlayerId = player.Id, GameId = game.Id };
        }
    }
}
