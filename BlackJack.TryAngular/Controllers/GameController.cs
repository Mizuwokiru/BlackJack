using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlackJack.TryAngular.Controllers
{
    [Authorize, ApiController, Route("api/[controller]")]
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IActionResult GetRoundsInfo()
        {
            return StatusResult(() =>
            {
                RoundInfoViewModel roundInfo = _gameService.GetRoundsInfo();
                return roundInfo;
            });
        }

        [HttpGet, Route("[action]")]
        public IActionResult Menu()
        {
            bool hasUnfinishedGame = _gameService.HasUnfinishedGame();
            var gameMenuViewModel = new GameMenuViewModel
            {
                HasUnfinishedGame = hasUnfinishedGame,
                MaxBotCount = BlackJackConstants.MaxBotCount
            };
            return gameMenuViewModel;
        }

        [HttpPost, Route("[action]")]
        public IActionResult New()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _gameService.NewGame(newGameViewModel.BotCount);
            return Ok();
        }

        [HttpPost, Route("[action]")]
        public IActionResult Step()
        {
            return StatusResult(() => _gameService.Step());
        }

        [HttpPost, Route("[action]")]
        public IActionResult Skip()
        {
            return StatusResult(() => _gameService.EndRound());
        }

        [HttpPost, Route("[action]")]
        public IActionResult NextRound()
        {
            return StatusResult(() => _gameService.NextRound());
        }

        [HttpPost, Route("[action]")]
        public IActionResult EndGame()
        {
            return StatusResult(() => _gameService.EndGame());
        }
    }
}