using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

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

        [HttpPost("{botCount}")]
        public ActionResult<GameViewModel> Create(int botCount, PlayerViewModel player)
        {
            Debug.WriteLine("GameController.Create");
            return _gameService.CreateGame(player.PlayerId, botCount);
        }

        [HttpGet("{gameId}")]
        public ActionResult<List<PlayerCardsViewModel>> GetRound(int gameId)
        {
            Debug.WriteLine("GameController.GetRound");
            return _gameService.GetRound(gameId);
        }
    }
}
