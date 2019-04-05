using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackJack.Web.Models;
using Microsoft.AspNetCore.Authorization;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Models;

namespace BlackJack.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IGameService _gameService;

        public HomeController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            bool canToContinueGame = await _gameService.CanToContinueGame();
            var menuViewModel = new MenuViewModel { CanToContinueGame = canToContinueGame };
            return View(menuViewModel);
        }

        public async Task<ActionResult> New()
        {

        }
    }
}
