﻿using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlackJack.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userLogin = new UserLoginViewModel
            {
                UserName = string.Empty,
                Users = _userService.GetUsers()
            };
            return View(userLogin);
        }

        [HttpPost]
        public IActionResult Menu(UserLoginViewModel userLogin)
        {
            UserModel user = _userService.GetOrCreateUser(userLogin.UserName);
            return View(user.Id);
        }

        public IActionResult CreateGame(int userId)
        {
            return View(new GameCreateViewModel { UserId = userId });
        }
    }
}