using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.TryAngular.Controllers
{
    [Authorize, ApiController, Route("api/[controller]")]
    public class MenuController : Controller
    {
        private readonly IGameService _gameService;

        public MenuController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public bool HasUnfinishedGame()
        {
            bool hasUnfinishedGame = _gameService.HasUnfinishedGame();
            return hasUnfinishedGame;
        }

        [HttpPost, Route("[action]")]
        public IActionResult NewGame(GameMenuViewModel gameMenuViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _gameService.NewGame(gameMenuViewModel.BotCount);
            return Ok();
        }

        [HttpPost, Route("[action]")]
        public IActionResult ContinueGame()
        {
            bool hasUnfinishedGame = HasUnfinishedGame();
            if (!hasUnfinishedGame)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
