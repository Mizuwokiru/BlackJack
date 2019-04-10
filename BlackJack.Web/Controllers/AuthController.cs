using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlackJack.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _loginService;

        public AuthController(IUserService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.UserNames = _loginService.GetUsers();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                user = _loginService.LoginUser(user.Name);
                await Authenticate(user.Name);

                return RedirectToAction("Menu", "Game");
            }
            ViewBag.UserNames = _loginService.GetUsers();
            return View(user);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            var identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties { ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10) });
        }
    }
}
