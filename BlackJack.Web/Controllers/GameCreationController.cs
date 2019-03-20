using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    public class GameCreationController : Controller
    {
        private IGameCreationService _gameCreationService;

        public GameCreationController(IGameCreationService service)
        {
            _gameCreationService = service;
        }

        public IActionResult Index()
        {
            return View(_gameCreationService.GetPlayables());
        }
    }
}
