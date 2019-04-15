using BlackJack.Services.Services;
using BlackJack.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlackJack.TryAngular.Controllers
{
    [Authorize, ApiController, Route("api/[controller]")]
    public class HistoryController : Controller
    {
        private readonly GameHistoryService _historyService;

        public HistoryController(GameHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public IEnumerable<HistoryGameViewModel> Get()
        {
            IEnumerable<HistoryGameViewModel> gamesHistory = _historyService.GetGamesHistory();
            return gamesHistory;
        }

        [HttpGet, Route("{gameOrderId}")]
        public IEnumerable<IEnumerable<RoundViewModel>> Get(int gameOrderId)
        {
            IEnumerable<IEnumerable<RoundViewModel>> roundsHistory = _historyService.GetRoundsHistory(gameOrderId);
            return roundsHistory;
        }
    }
}