using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackJack.WebMVC.Models;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Models;

namespace BlackJack.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoginService _loginService;

        public HomeController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.PlayerNames = _loginService.GetPlayerNames();
            return View();
        }

        [HttpPost]
        public IActionResult Index(PlayerViewModel user)
        {
            if (ModelState.IsValid)
            {
                user = _loginService.GetPlayer(user.PlayerName);
                return Content($"{user.PlayerId} {user.PlayerName}");
            }
            ViewBag.PlayerNames = _loginService.GetPlayerNames();
            return View(user);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
