using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.History;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            GamesHistoryViewModel gamesHistory = _historyService.GetGamesHistory();
            return Ok(gamesHistory);
        }

        [Route("{gameSkipCount}")]
        [HttpGet]
        public IActionResult Get(int gameSkipCount)
        {
            RoundsHistoryViewModel roundsHistory = _historyService.GetRoundsHistory(gameSkipCount);
            return Ok(roundsHistory);
        }

        [Route("{gameSkipCount}/{roundSkipCount}")]
        [HttpGet]
        public IActionResult Get(int gameSkipCount, int roundSkipCount)
        {
            GameViewModel roundInfo = _historyService.GetRoundInfo(gameSkipCount, roundSkipCount);
            return Ok(roundInfo);
        }
    }
}