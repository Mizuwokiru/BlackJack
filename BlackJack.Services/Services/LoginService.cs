using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Models;
using System.Collections.Generic;

namespace BlackJack.Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly IPlayerRepository _playerRepository;

        public LoginService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public PlayerViewModel GetPlayer(string playerName)
        {
            Player player = _playerRepository.GetPlayer(playerName);
            if (player == null)
            {
                player = new Player { Name = playerName, Type = PlayerType.User };
                _playerRepository.Add(player);
            }

            var playerViewModel = new PlayerViewModel { PlayerId = player.Id, PlayerName = playerName };
            return playerViewModel;
        }

        public IEnumerable<string> GetPlayerNames()
        {
            IEnumerable<string> playerNames = _playerRepository.GetPlayerNames();
            return playerNames;
        }
    }
}
