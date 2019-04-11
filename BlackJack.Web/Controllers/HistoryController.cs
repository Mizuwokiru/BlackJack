using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            IEnumerable<HistoryGameViewModel> historyGameViewModels = _historyService.GetGamesHistory();
            return View(historyGameViewModels);
        }

        [Route("[action]/{page}")]
        public IActionResult Game(int page)
        {
            return View(page);
        }
    }
}
