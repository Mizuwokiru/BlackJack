using BlackJack.DataAccess.Entities;
using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlackJack.WebMvc.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthenticationController(ILoginService loginService,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _loginService = loginService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

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
                UserNames = _loginService.GetUsers().UserNames
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

            ClaimsIdentity claimsIdentity = await _loginService.Login(loginViewModel.Name);
            User user = await _userManager.FindByNameAsync(loginViewModel.Name);
            await _signInManager.SignInAsync(user, true);
            ((ClaimsIdentity)User.Identity).AddClaims(claimsIdentity.Claims);
            Debug.WriteLine(User.Identity.Name);
            Debug.WriteLine(User.Identity.IsAuthenticated);
            return RedirectToAction("Menu", "Game");
        }
    }
}