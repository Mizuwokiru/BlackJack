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

        public async Task<IActionResult> Game()
        {
            return View();
        }

        public async Task<IActionResult> NewGame()
        {
            // TODO: create game and redirect to Game
            return Content(string.Empty);
        }

        public async Task<IActionResult> ContinueGame()
        {
            // TODO: continue game and redirect to Game
            return Content(string.Empty);
        }

        public async Task<IActionResult> Step()
        {
            // TODO: get card and redirect to Game
            return Content(string.Empty);
        }

        public async Task<IActionResult> Skip()
        {
            // TODO: finish round and redirect to Game
            return Content(string.Empty);
        }

        public async Task<IActionResult> NextRound()
        {
            // TODO: create round and redirect to Game
            return Content(string.Empty);
        }

        public async Task<IActionResult> FinishGame()
        {
            // TODO: finish game and redirect to Index
            return Content(string.Empty);
        }
    }
}
