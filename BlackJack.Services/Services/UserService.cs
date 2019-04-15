using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Options;
using BlackJack.ViewModels.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlackJack.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly JwtSettingsOptions _jwtSettings;

        public UserService(IPlayerRepository playerRepository,
            IOptions<JwtSettingsOptions> options)
        {
            _playerRepository = playerRepository;
            _jwtSettings = options.Value;
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

            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_jwtSettings.TokenSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToLower())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string serializedToken = tokenHandler.WriteToken(token);

            var userViewModel = new UserViewModel { Name = user.Name, Token = serializedToken };
            return userViewModel;
        }
    }
}
