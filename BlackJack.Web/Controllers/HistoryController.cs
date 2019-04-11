using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class HistoryController : Controller
    {
        private readonly IGameHistoryService _historyService;

        public HistoryController(IGameHistoryService historyService)
        {
            _historyService = historyService;
        }

        [Route("")]
        [Route("[action]")]
        public IActionResult Index()
        {
            List<HistoryGameViewModel> historyGameViewModels = _historyService.GetGamesHistory().ToList();
            return View(historyGameViewModels);
        }

        [Route("[action]/{id}")]
        public IActionResult Game(int id)
        {
            List<HistoryRoundsViewModel> historyRoundsViewModel = _historyService.GetRoundsHistory(id).ToList();
            return View(historyRoundsViewModel);
        }
    }
}
