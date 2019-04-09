using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            List<RoundViewModel> roundViewModels = _gameService.GetRoundsInfo();
            return View(roundViewModels);
        }

        // TODO: New game
        public IActionResult NewGame(GameMenuViewModel gameMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                _gameService.NewGame(gameMenuViewModel.BotCount);
                //return RedirectToAction(nameof(Game));
                return Content("NewGame");
            }
            return View("Menu", gameMenuViewModel);
        }

        // TODO: Continue game
        public IActionResult ContinueGame()
        {
            return Content("ContinueGame");
        }

        // TODO: Step
        public IActionResult Step()
        {
            return Content("Step");
        }

        // TODO: End round
        public IActionResult EndRound()
        {
            return Content("EndRound");
        }

        // TODO: Next round
        public IActionResult NextRound()
        {
            return Content("NextRound");
        }

        // TODO: End game
        public IActionResult EndGame()
        {
            return Content("EndGame");
        }

        // TODO: Quit
        public IActionResult Quit()
        {
            return Content("Quit");
        }

    }
}
