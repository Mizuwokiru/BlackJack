using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoginService _loginService;

        public HomeController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View(new LoginViewModel { Players = _loginService.GetPlayers() });
        }

        [Route("[controller]/PlayerByName/{name}")]
        [Produces("application/json")]
        public PlayerModel GetOrCreatePlayer(string name)
        {
            return _loginService.GetOrCreatePlayer(name);
        }
    }
}