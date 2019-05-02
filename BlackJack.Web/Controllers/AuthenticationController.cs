using BlackJack.Services.Services.Interfaces;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly JwtSettingsOptions _jwtSettings;

        public AuthenticationController(IAuthenticationService authenticationService,
            IOptions<JwtSettingsOptions> options)
        {
            _authenticationService = authenticationService;
            _jwtSettings = options.Value;
        }

        [HttpGet("Login")]
        public IActionResult GetUsers()
        {
            UserNamesViewModel users = _authenticationService.GetUserNames();
            return Ok(users);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _authenticationService.Login(user.Name);

            var now = DateTime.UtcNow;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
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
            var apiUser = new UserViewModel { Name = user.Name, Token = encryptedToken };
            return Ok(apiUser);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();
            return Ok();
        }
    }
}