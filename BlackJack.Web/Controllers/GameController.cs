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
        private readonly ICardService _cardService;
        private readonly IGameService _gameService;

        public GameController(ICardService cardService,
            IGameService gameService)
        {
            _cardService = cardService;
            _gameService = gameService;
        }

        [HttpPost("{botCount}")]
        public ActionResult<int> CreateGame(int botCount, PlayerViewModel player)
        {
            return _gameService.CreateGame(player.Id, botCount);
        }

        [HttpPost("{gameId}")]
        public ActionResult<RoundViewModel> CreateRound(int gameId)
        {
            return _gameService.CreateRound(gameId);
        }

        [HttpPost("{gameId}")]
        public ActionResult<string> FinishRound(int gameId)
        {
            _gameService.FinishRound(gameId);
            return "Finished!";
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<int>> ShuffleCards()
        //{
        //    return _cardService.GetShuffledCardIds().ToList();
        //}
    }
}
