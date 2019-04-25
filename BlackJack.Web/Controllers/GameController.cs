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
            GameViewModel roundInfo = _gameService.GetRoundInfo();
            return Ok(roundInfo);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Menu()
        {
            MenuMenuGameViewModel menu = _gameService.GetMenu();
            return Ok(menu);
        }
        
        [HttpPost]
        public IActionResult New([FromBody]NewMenuGameViewModel newGameViewModel)
        {
            if (!ModelState.IsValid)
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