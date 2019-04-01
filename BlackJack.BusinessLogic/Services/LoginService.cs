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

        public List<string> GetPlayersNames()
        {
            return _playerRepository.GetPlayers().Select(player => player.Name).ToList();
        }

        public PlayerViewModel GetOrCreatePlayer(string playerName)
        {
            if (!Regex.IsMatch(playerName, @"^\w+$"))
            {
                throw new ValidationException($"Player name is not valid ({playerName})");
            }

            Player playerFromDb = _playerRepository.GetOrCreatePlayer(playerName);

            return new PlayerViewModel { PlayerId = playerFromDb.Id, PlayerName = playerFromDb.Name };
        }

        public PlayerViewModel GetPlayer(int playerId)
        {
            var playerFromDb = _playerRepository.Get(playerId);
            if (playerFromDb == null || !playerFromDb.IsPlayable)
            {
                throw new InvalidOperationException($"Player with id {playerId} is not exists.");
            }
            return new PlayerViewModel { PlayerId = playerFromDb.Id, PlayerName = playerFromDb.Name };
        }
    }
}
