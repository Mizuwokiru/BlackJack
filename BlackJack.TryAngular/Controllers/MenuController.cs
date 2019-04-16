using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared;
using BlackJack.ViewModels.Models.Menu;
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
        public GameMenuViewModel GetMenu()
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
        public IActionResult NewGame([FromBody]NewGameViewModel newGameViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _gameService.NewGame(newGameViewModel.BotCount);
            return Ok();
        }
    }
}
