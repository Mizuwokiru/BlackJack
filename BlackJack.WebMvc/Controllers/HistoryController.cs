using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.History;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WebMvc.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult GamesHistory()
        {
            GamesHistoryViewModel gamesHistory = _historyService.GetGamesHistory();
            return View(gamesHistory);
        }

        [Route("{gameSkipCount}")]
        [HttpGet]
        public IActionResult RoundsHistory(int gameSkipCount)
        {
            RoundsHistoryViewModel roundsHistory = _historyService.GetRoundsHistory(gameSkipCount);
            return View(roundsHistory);
        }

        [Route("{gameSkipCount}/{roundSkipCount}")]
        [HttpGet]
        public IActionResult RoundInfo(int gameSkipCount, int roundSkipCount)
        {
            GameViewModel roundInfo = _historyService.GetRoundInfo(gameSkipCount, roundSkipCount);
            return View(roundInfo);
        }
    }
}