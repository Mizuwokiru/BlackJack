using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IUserService _userService;

        private readonly IGameService _gameService;

        public GameController(IGameService gameService,
            IUserService userService)
        {
            _gameService = gameService;
            _userService = userService;
        }

        public IActionResult Index(GameCreateViewModel gameCreate)
        {
            var userName = _userService.GetUser(gameCreate.UserId);
            return View("Index", $"User {userName} created game with {gameCreate.BotCount} bots!");
        }

        /*public IActionResult Index(int userId, int botCount)
        {
            
            return View("Index", $"{userId} {botCount}");
        }*/
    }
}