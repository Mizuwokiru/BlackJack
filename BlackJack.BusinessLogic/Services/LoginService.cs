using BlackJack.BusinessLogic.Exceptions;
using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
                throw new PlayerValidationException(playerName);
            }

            Player playerFromDb = _playerRepository.GetOrCreatePlayer(playerName);

            return new PlayerViewModel { PlayerId = playerFromDb.Id, PlayerName = playerFromDb.Name };
        }
    }
}
