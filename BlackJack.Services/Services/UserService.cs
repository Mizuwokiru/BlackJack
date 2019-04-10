using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Enums;
using BlackJack.ViewModels.Models;
using System.Collections.Generic;

namespace BlackJack.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IPlayerRepository _playerRepository;

        public UserService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public IEnumerable<string> GetUsers()
        {
            IEnumerable<string> users = _playerRepository.GetUsers();
            return users;
        }

        public UserViewModel LoginUser(string name)
        {
            Player user = _playerRepository.GetUser(name);
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
