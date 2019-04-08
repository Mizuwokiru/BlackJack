using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult Index()
        {
            bool canToContinueGame = _gameService.CanToContinueGame();
            var menuViewModel = new MenuViewModel { CanToContinueGame = canToContinueGame };
            return View(menuViewModel);
        }

        [HttpGet]
        public IActionResult Game()
        {
            List<GamePlayerInfoViewModel> gamePlayerInfoViewModels =
                _gameService.GetGameInfo();
            return View(gamePlayerInfoViewModels);
        }

        [HttpPost]
        public IActionResult NewGame(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                _gameService.NewGame(menuViewModel.BotCount);
                return RedirectToAction(nameof(Game));
            }
            return View(nameof(Index), menuViewModel);
        }

        [HttpPost]
        public IActionResult ContinueGame()
        {
            _gameService.ContinueGame();
            return RedirectToAction(nameof(Game));
        }

        [HttpPost]
        public IActionResult Step()
        {
            _gameService.Step();
            return RedirectToAction(nameof(Game));
        }

        [HttpPost]
        public IActionResult Skip()
        {
            _gameService.Skip();
            return RedirectToAction(nameof(Game));
        }

        [HttpPost]
        public IActionResult NextRound()
        {
            _gameService.NextRound();
            return RedirectToAction(nameof(Game));
        }

        [HttpPost]
        public IActionResult FinishGame()
        {
            _gameService.FinishGame();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Quit()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
