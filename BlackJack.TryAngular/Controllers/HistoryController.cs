using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models.Game;
using BlackJack.ViewModels.Models.History;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlackJack.TryAngular.Controllers
{
    [Authorize, ApiController, Route("api/[controller]")]
    public class HistoryController : BaseController
    {
        private readonly IGameHistoryService _historyService;

        public HistoryController(IGameHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public IEnumerable<HistoryGameViewModel> Get()
        {
            IEnumerable<HistoryGameViewModel> gamesHistory = _historyService.GetGamesHistory();
            return gamesHistory;
        }

        [HttpGet, Route("{gameId}")]
        public IActionResult Get(int gameId)
        {
            return StatusResult(() =>
            {
                HistoryRoundsViewModel roundsHistory = _historyService.GetRoundsHistory(gameId);
                return roundsHistory;
            });
        }

        [HttpGet, Route("{gameId}/{roundId}")]
        public IActionResult Get(int gameId, int roundId)
        {
            return StatusResult(() =>
            {
                IEnumerable<RoundViewModel> roundInfos = _historyService.GetRoundInfo(gameId, roundId);
                return roundInfos;
            });
        }
    }
}