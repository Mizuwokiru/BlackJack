using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Error;
using BlackJack.ViewModels.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ILogger _logger;

        public GameController(IGameService gameService,
            ILogger<GameController> logger)
        {
            _gameService = gameService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            RoundInfoViewModel roundInfo = _gameService.GetRoundInfo();
            return Ok(roundInfo);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Menu()
        {
            MenuViewModel menu = _gameService.GetMenu();
            return Ok(menu);
        }
        
        [HttpPost]
        public IActionResult New([FromBody]NewGameViewModel newGameViewModel)
        {
            if (!ModelState.IsValid) // TODO: DRY
            {
                return BadRequest(ModelState);
            }

            _gameService.NewGame(newGameViewModel.BotCount);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Step()
        {
            _gameService.Step();
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Skip()
        {
            _gameService.Skip();
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult NextRound()
        {
            _gameService.NextRound();
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult EndGame()
        {
            _gameService.EndGame();
            return Ok();
        }
    }
}