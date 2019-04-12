using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlackJack.TryAngular.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            IEnumerable<string> userNames = _userService.GetUsers();
            return userNames;
        }

        [HttpPost, ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user = _userService.LoginUser(user.Name);
            return Ok(user);
        }
    }
}
