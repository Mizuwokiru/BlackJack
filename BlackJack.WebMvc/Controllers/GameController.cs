﻿using BlackJack.Services.Services.Interfaces;
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

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Menu));
        }

        [HttpGet]
        public IActionResult Game()
        {
            GameViewModel game = _gameService.GetLastRoundInfo();
            return View(game);
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult Step()
        {
            _gameService.Step();
            return RedirectToAction(nameof(Game));
        }

        [HttpGet]
        public IActionResult Skip()
        {
            _gameService.Skip();
            return RedirectToAction(nameof(Game));
        }

        [HttpGet]
        public IActionResult NextRound()
        {
            _gameService.NextRound();
            return RedirectToAction(nameof(Game));
        }

        [HttpGet]
        public IActionResult EndGame()
        {
            _gameService.EndGame();
            return RedirectToAction(nameof(Menu));
        }
    }
}