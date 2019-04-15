using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlackJack.TryAngular.Controllers
{
    [Authorize, ApiController, Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IEnumerable<RoundViewModel> GetRoundsInfo()
        {
            IEnumerable<RoundViewModel> roundViewModels = _gameService.GetRoundsInfo();
            return roundViewModels;
        }

        [HttpPost, Route("[action]")]
        public IActionResult Step()
        {
            _gameService.Step();
            return Ok();
        }

        [HttpPost, Route("[action]")]
        public IActionResult Skip()
        {
            _gameService.EndRound();
            return Ok();
        }

        [HttpPost, Route("[action]")]
        public IActionResult NextRound()
        {
            _gameService.NextRound();
            return Ok();
        }

        [HttpPost, Route("[action]")]
        public IActionResult EndGame()
        {
            _gameService.EndGame();
            return Ok();
        }
    }
}