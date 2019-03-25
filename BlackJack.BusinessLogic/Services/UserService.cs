using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            IEnumerable<User> usersFromDb = _userRepository.GetAll();
            var users = new List<UserModel>();
            foreach (var userFromDb in usersFromDb)
            {
                users.Add(new UserModel { Id = userFromDb.Id, Name = userFromDb.Name });
            }
            return users;
        }

        public UserModel GetOrCreateUser(string userName)
        {
            if (!Regex.IsMatch(userName, @"^\w+$"))
            {
                throw new ValidationException($"User name is not valid ({userName}");
            }

            User userFromDb = _userRepository.GetUserByName(userName);

            if (userFromDb == null)
            {
                userFromDb = new User { Name = userName };
                _userRepository.Add(userFromDb);
            }

            return new UserModel { Id = userFromDb.Id, Name = userFromDb.Name };
        }

        public UserModel GetUser(int userId)
        {
            var userFromDb = _userRepository.Get(userId);
            if (userFromDb == null)
            {
                throw new InvalidOperationException($"User with id {userId} is not exists.");
            }
            return new UserModel { Id = userFromDb.Id, Name = userFromDb.Name };
        }
    }
}
