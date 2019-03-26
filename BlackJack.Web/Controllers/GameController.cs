using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlackJack.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ICardService _cardService;
        private readonly IGameService _gameService;

        public GameController(ILoginService loginService,
            ICardService cardService,
            IGameService gameService)
        {
            _loginService = loginService;
            _cardService = cardService;
            _gameService = gameService;
        }

        [Route("[controller]/{userId}_{botCount}")]
        public IActionResult Index(int userId, int botCount)
        {
            var players = new List<PlayerModel> { _loginService.GetPlayer(userId) };
            //players.AddRange(_gameService.GetOrCreateBots(botCount));
            return View(new GameViewModel { GameId = botCount, Players = players });
        }

        
    }
}