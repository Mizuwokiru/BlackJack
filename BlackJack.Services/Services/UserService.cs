using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IPlayerRepository _playerRepository;

        public UserService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<string>> GetUsers()
        {
            IEnumerable<string> users = await _playerRepository.GetUserNames();
            return users;
        }

        public async Task<UserViewModel> LoginUser(string name)
        {
            Player user = await _playerRepository.GetPlayer(name);
            if (user == null)
            {
                user = new Player { Name = name, Type = PlayerType.User };
                _playerRepository.Add(user);
            }

            var userViewModel = new UserViewModel { Name = user.Name };
            return userViewModel;
        }
    }
}
