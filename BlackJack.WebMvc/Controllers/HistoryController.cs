using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WebMvc.Controllers
{
    [Authorize]
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}