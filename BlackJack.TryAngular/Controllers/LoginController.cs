using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared;
using BlackJack.Shared.Options;
using BlackJack.ViewModels.Models.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.TryAngular.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class LoginController : BaseController
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
        public async Task<IActionResult> Post([FromBody]UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ClaimsIdentity claimsIdentity = await _userService.LoginUser(userViewModel.Name);

            var now = DateTime.UtcNow;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userViewModel.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                claimsIdentity.FindFirst(BlackJackConstants.ClaimPlayerId)
            };
            byte[] key = Encoding.ASCII.GetBytes(_jwtSettings.TokenSecret);
            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                now,
                now.AddMinutes(_jwtSettings.Lifetime),
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));
            string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
            userViewModel.Token = serializedToken;

            return Ok(userViewModel);
        }
    }
}
