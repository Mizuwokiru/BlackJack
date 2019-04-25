using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlackJack.WebMvc.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILoginService _loginService;

        public AuthenticationController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginViewModel = new LoginViewModel
            {
                UserNames = _loginService.GetUsers(),
                User = new UserViewModel()
            };
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ClaimsIdentity claimsIdentity = await _loginService.Login(loginViewModel.User);
            claimsIdentity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, loginViewModel.User.Name));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return RedirectToAction("Menu", "Game");
        }
    }
}