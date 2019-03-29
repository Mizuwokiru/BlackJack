using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: api/Login
        [HttpGet]
        public ActionResult<List<string>> GetPlayers()
        {
            return _loginService.GetPlayersNames();
        }

        // POST: api/Login
        [HttpPost]
        public ActionResult<PlayerViewModel> GetOrCreatePlayer(PlayerViewModel player)
        {
            return _loginService.GetOrCreatePlayer(player.PlayerName);
        }
    }
}
