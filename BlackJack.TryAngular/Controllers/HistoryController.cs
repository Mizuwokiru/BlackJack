using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models.Game;
using BlackJack.ViewModels.Models.History;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlackJack.TryAngular.Controllers
{
    [Authorize, ApiController, Route("api/[controller]")]
    public class HistoryController : Controller
    {
        private readonly IGameHistoryService _historyService;

        public HistoryController(IGameHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public IEnumerable<GameViewModel> Get()
        {
            IEnumerable<GameViewModel> gamesHistory = _historyService.GetGamesHistory();
            return gamesHistory;
        }

        [HttpGet, Route("{gameId}")]
        public GameRoundsViewModel Get(int gameId)
        {
            GameRoundsViewModel roundsHistory = _historyService.GetRoundsHistory(gameId);
            return roundsHistory;
        }

        [HttpGet, Route("{gameId}/{roundId}")]
        public IEnumerable<RoundViewModel> Get(int gameId, int roundId)
        {
            IEnumerable<RoundViewModel> roundInfos = _historyService.GetRoundInfo(gameId, roundId);
            return roundInfos;
        }
    }
}