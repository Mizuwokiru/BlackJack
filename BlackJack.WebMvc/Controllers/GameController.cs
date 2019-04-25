using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WebMvc.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Menu));
        }

        public IActionResult Game()
        {
            GameViewModel game = _gameService.GetRoundInfo();
            return View(game);
        }

        public IActionResult Menu()
        {
            var menu = new MenuGameViewModel
            {
                HasUnfinishedGame = _gameService.GetMenu().HasUnfinishedGame
            };
            return View(menu);
        }

        [HttpPost]
        public IActionResult Menu([FromBody] MenuGameViewModel menu)
        {
            if (!ModelState.IsValid)
            {
                return View(menu);
            }
            _gameService.NewGame(menu.BotCount);
            return RedirectToAction(nameof(Game));
        }

        public IActionResult Step()
        {
            _gameService.Step();
            return RedirectToAction(nameof(Game));
        }

        public IActionResult EndRound()
        {
            _gameService.Skip();
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