using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Models;

namespace BlackJack.WebMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.PlayerNames = _loginService.GetPlayerNames();
            return View();
        }

        public async Task<IActionResult> Login(PlayerViewModel player)
        {
            if (ModelState.IsValid)
            {
                player = _loginService.GetPlayer(player.Name);
                await Authenticate(player.Name);

                return RedirectToAction("Index", "Home");
            }
            ViewBag.PlayerNames = _loginService.GetPlayerNames();
            return View(player);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            var identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }
    }
}
