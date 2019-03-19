using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    public class StartGameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
