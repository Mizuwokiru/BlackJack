using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Helpers;
using BlackJack.ViewModels.Login;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlackJack.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticationService(IPlayerRepository playerRepository,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _playerRepository = playerRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public UserNamesViewModel GetUserNames()
        {
            var userNames = new UserNamesViewModel
            {
                UserNames = _playerRepository.GetUserNames()
            };
            return userNames;
        }

        public async Task Login(string userName)
        {
            IdentityUser user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                Player player = new Player { Name = userName, Type = PlayerType.User };
                _playerRepository.Add(player);
                user = new IdentityUser { UserName = userName };
                await _userManager.CreateAsync(user);
                await _userManager.AddClaimAsync(user, new Claim(Constants.ClaimPlayerId, player.Id.ToString(), ClaimValueTypes.Integer64));
            }
            await _signInManager.SignInAsync(user, false);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
