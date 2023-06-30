using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Greendy.API.ViewModels.Account;
using Greendy.Application.Interfaces;

namespace Greendy.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accountService;
        public AccountController(IConfiguration configuration,
            IAccountService accountService)
        {
            _configuration = configuration;
            _accountService = accountService;
        }

		[Authorize]
		[HttpPost("isAuthorized")]
		public IActionResult IsAuthorized() 
		{
			return Ok(true);
		}

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var isUserAlreadyExists = await _accountService.CheckUserExistanceAsync(model.Username);
            if (isUserAlreadyExists) {
                throw new Exception($"Sorry user with this username: '{model.Username}' already exists");
            }
            var role = "User";
            var userId = await _accountService.RegisterAsync(new Application.DTO.Accounts.RegisterAccountRequest(model.FirstName, model.LastName, model.Username,
                model.Password, model.Email, model.PhoneNumber, role));
            var token = CreateToken(model.Username, role);
            return Ok(new {Token = token});
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model) 
        {
            var response = await _accountService.ValidateLoginAsync(model.Login, model.Password);
            var token = CreateToken(response.Username, response.Role); 
            return Ok(new {Token = token});
        }

        private string CreateToken(string username, string role)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Key").Value!
            ));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("JWT:Issuer").Value!,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
