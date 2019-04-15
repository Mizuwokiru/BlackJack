using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Options;
using BlackJack.ViewModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlackJack.TryAngular.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly JwtSettingsOptions _jwtSettings;

        public LoginController(IUserService userService,
            IOptions<JwtSettingsOptions> options)
        {
            _userService = userService;
            _jwtSettings = options.Value;
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
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_jwtSettings.TokenSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToLower())
                }),
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string serializedToken = tokenHandler.WriteToken(token);
            user.Token = serializedToken;
            return Ok(user);
        }
    }
}
