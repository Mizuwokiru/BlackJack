using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models;
using BlackJack.ViewModels.Models.Menu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BlackJack.Web.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public IActionResult Menu()
        {
            bool hasUnfinishedGame = _gameService.HasUnfinishedGame();
            var gameMenuViewModel = new GameMenuViewModel { HasUnfinishedGame = hasUnfinishedGame };
            return View(gameMenuViewModel);
        }

        public IActionResult Game()
        {
            List<RoundViewModel> roundViewModels = _gameService.GetRoundsInfo().ToList();
            return View(roundViewModels);
        }

        public IActionResult NewGame(NewGameViewModel newGameViewModel)
        {
            if (ModelState.IsValid)
            {
                _gameService.NewGame(newGameViewModel.BotCount);
                return RedirectToAction(nameof(Game));
            }
            return View("Menu", newGameViewModel);
        }

        public IActionResult ContinueGame()
        {
            return RedirectToAction(nameof(Game));
        }

        public IActionResult Step()
        {
            _gameService.Step();
            return RedirectToAction(nameof(Game));
        }

        public IActionResult EndRound()
        {
            _gameService.EndRound();
            return RedirectToAction(nameof(Game));
        }

        public IActionResult NextRound()
        {
            _gameService.NextRound();
            return RedirectToAction(nameof(Game));
        }

        public IActionResult EndGame()
        {
            _gameService.EndGame();
            return RedirectToAction(nameof(Menu));
        }

        public IActionResult Quit()
        {
            return RedirectToAction(nameof(Menu));
        }
    }
}
