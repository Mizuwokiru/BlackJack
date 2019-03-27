using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.BusinessLogic.Services
{
    public class LoginService : ILoginService
    {
        private IPlayerRepository _playerRepository;

        public LoginService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public IEnumerable<PlayerViewModel> GetPlayers()
        {
            IEnumerable<Player> playersFromDb = _playerRepository.GetPlayers();
            var players = new List<PlayerViewModel>();
            foreach (var playerFromDb in playersFromDb)
            {
                players.Add(new PlayerViewModel { Id = playerFromDb.Id, Name = playerFromDb.Name });
            }
            return players;
        }

        public PlayerViewModel GetOrCreatePlayer(string playerName)
        {
            if (!Regex.IsMatch(playerName, @"^\w+$"))
            {
                throw new ValidationException($"Player name is not valid ({playerName})");
            }

            Player playerFromDb = _playerRepository.GetPlayerByName(playerName);

            if (playerFromDb == null)
            {
                playerFromDb = new Player { Name = playerName };
                _playerRepository.Add(playerFromDb);
            }

            return new PlayerViewModel { Id = playerFromDb.Id, Name = playerFromDb.Name };
        }

        public PlayerViewModel GetPlayer(int playerId)
        {
            var playerFromDb = _playerRepository.Get(playerId);
            if (playerFromDb == null || playerFromDb.IsBot)
            {
                throw new InvalidOperationException($"Player with id {playerId} is not exists.");
            }
            return new PlayerViewModel { Id = playerFromDb.Id, Name = playerFromDb.Name };
        }
    }
}
