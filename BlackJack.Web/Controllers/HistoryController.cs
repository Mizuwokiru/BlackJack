using BlackJack.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class HistoryController : Controller
    {
        private IGameHistoryService _historyService;

        public HistoryController(IGameHistoryService historyService)
        {
            _historyService = historyService;
        }

        [Route("")]
        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]/{page}")]
        public IActionResult Game(int page)
        {
            return View(page);
        }
    }
}
