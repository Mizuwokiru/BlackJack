using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Helpers;
using BlackJack.Shared.Options;
using BlackJack.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly JwtSettingsOptions _jwtSettings;

        public LoginController(ILoginService loginService,
            IOptions<JwtSettingsOptions> options)
        {
            _loginService = loginService;
            _jwtSettings = options.Value;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            UserNamesViewModel users = _loginService.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            ClaimsIdentity claimsIdentity = await _loginService.Login(user);

            var now = DateTime.UtcNow;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                claimsIdentity.FindFirst(Constants.ClaimPlayerId)
            };
            byte[] key = Encoding.ASCII.GetBytes(_jwtSettings.TokenSecret);
            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                now,
                now.AddMinutes(_jwtSettings.Lifetime),
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));
            string encryptedToken = new JwtSecurityTokenHandler().WriteToken(token);
            var apiUser = new ApiUserViewModel { Name = user.Name, Token = encryptedToken };
            return Ok(apiUser);
        }
    }
}