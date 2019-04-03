using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetPlayers()
        {
            IEnumerable<string> playerNames = _loginService.GetPlayerNames();
            return Ok(playerNames.ToList());
        }

        [HttpPost]
        public ActionResult<PlayerViewModel> CreatePlayer(PlayerViewModel player)
        {
            if (ModelState.IsValid)
            {
                player = _loginService.GetPlayer(player.PlayerName);
                return Ok(player);
            }
            return BadRequest(ModelState);
        }
    }
}