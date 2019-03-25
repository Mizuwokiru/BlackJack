using BlackJack.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public IActionResult Index(int userId, int botCount)
        {
            
            return View("Index", $"{userId} {botCount}");
        }
    }
}