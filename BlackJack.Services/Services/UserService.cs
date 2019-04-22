using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Options;
using BlackJack.ViewModels.Models.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly UserManager<User> _userManager;
        private readonly JwtSettingsOptions _jwtSettings;

        public UserService(IPlayerRepository playerRepository,
            UserManager<User> userManager,
            IOptions<JwtSettingsOptions> options)
        {
            _playerRepository = playerRepository;
            _userManager = userManager;
            _jwtSettings = options.Value;
        }

        public IEnumerable<string> GetUsers()
        {
            IEnumerable<string> users = _userManager.Users.Select(user => user.UserName);
            return users;
        }

        public async Task<ClaimsIdentity> LoginUser(string name)
        {
            User user = await _userManager.FindByNameAsync(name.ToLowerInvariant());
            if (user == null)
            {
                Player player = new Player { Name = name, Type = PlayerType.User };
                _playerRepository.Add(player);
                user = new User { UserName = name, PlayerId = player.Id };
                await _userManager.CreateAsync(user);
            }

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(BlackJackConstants.ClaimPlayerId, user.PlayerId.ToString(), ClaimValueTypes.Integer64)
            });

            return await Task.FromResult(claimsIdentity);
        }
    }
}
