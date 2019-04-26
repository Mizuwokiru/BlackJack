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
    public class LoginService : ILoginService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginService(IPlayerRepository playerRepository,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _playerRepository = playerRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public UserNamesViewModel GetUsers()
        {
            var userNames = new UserNamesViewModel
            {
                UserNames = _playerRepository.GetUsers()
            };
            return userNames;
        }

        public async Task Login(string userName)
        {
            User user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                Player player = new Player { Name = userName, Type = PlayerType.User };
                _playerRepository.Add(player);
                user = new User { UserName = userName, PlayerId = player.Id };
                await _userManager.CreateAsync(user);
                await _userManager.AddClaimAsync(user, new Claim(Constants.ClaimPlayerId, user.PlayerId.ToString(), ClaimValueTypes.Integer64));
            }
            await _signInManager.SignInAsync(user, false);
        }
    }
}
