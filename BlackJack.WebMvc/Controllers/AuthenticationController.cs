using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.WebMvc.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Menu", "Game");
            }
            var login = new LoginViewModel
            {
                UserNames = _authenticationService.GetUserNames().UserNames
            };
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginViewModel);
            }

            await _authenticationService.Login(loginViewModel.Name);
            return RedirectToAction("Menu", "Game");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();
            return RedirectToAction(nameof(Login));
        }
    }
}