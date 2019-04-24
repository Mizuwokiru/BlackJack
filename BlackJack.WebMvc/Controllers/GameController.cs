using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WebMvc.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Menu));
        }

        public IActionResult Menu()
        {
            return View();
        }
    }
}