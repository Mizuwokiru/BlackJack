using BlackJack.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public ActionResult<bool> CanContinue(int playerId)
        {
            bool hasUnfinishedGames = _gameService.HasUnfinishedGames(playerId);
            return hasUnfinishedGames;
        }
    }
}