using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private ICardService _cardService;

        public GameController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost("{botCount}")]
        public ActionResult<string> Create(int botCount, PlayerViewModel player)
        {
            return $"Bot count is {botCount}. Player - {player.Name}";
        }

        [HttpGet]
        public ActionResult<IEnumerable<int>> ShuffleCards()
        {
            return _cardService.GetShuffledCardIds().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CardViewModel> Card(int id)
        {
            return _cardService.GetCard(id);
        }
    }
}
