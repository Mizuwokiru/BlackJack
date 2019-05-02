using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            GameViewModel roundInfo = _gameService.GetLastRoundInfo();
            return Ok(roundInfo);
        }

        [HttpGet("Menu")]
        public IActionResult Menu()
        {
            MenuViewModel menu = _gameService.GetMenu();
            return Ok(menu);
        }

        [HttpPost]
        public IActionResult New([FromBody]NewGameViewModel newGameViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _gameService.NewGame(newGameViewModel.BotCount);
            return Ok();
        }
        
        [HttpPost("Step")]
        public IActionResult Step()
        {
            _gameService.Step();
            return Ok();
        }

        [HttpPost("Skip")]
        public IActionResult Skip()
        {
            _gameService.Skip();
            return Ok();
        }

        [HttpPost("NextRound")]
        public IActionResult NextRound()
        {
            _gameService.NextRound();
            return Ok();
        }

        [HttpPost("EndGame")]
        public IActionResult EndGame()
        {
            _gameService.EndGame();
            return Ok();
        }
    }
}