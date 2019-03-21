using System.Collections.Generic;
using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    public class GameCreationController : Controller
    {
        private IGameCreationService _gameCreationService;

        public GameCreationController(IGameCreationService service)
        {
            _gameCreationService = service;
        }

        public IActionResult Index()
        {
            IEnumerable<PlayerViewModel> playerList = _gameCreationService.GetPlayables();

            return View(playerList);
        }

        public IActionResult CreateGame(string playerName, int botCount)
        {
            GameCreationViewModel createdGame = _gameCreationService.CreateGame(playerName, botCount);

            return View(createdGame);
        }
    }
}