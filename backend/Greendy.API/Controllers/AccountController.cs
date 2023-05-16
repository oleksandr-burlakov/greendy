using System.Security.Cryptography;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Greendy.API.ViewModels.Account;
using MediatR;
using Greendy.BLL.Queries;
using Greendy.BLL.Commands;

namespace Greendy.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        public AccountController(IConfiguration configuration,
            IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet("CheckAuthentication")]
        public async Task<IActionResult> IsAuthenticated() 
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var isUserAlreadyExists = await _mediator.Send(new IsUserWithUsernameExistsQuery(model.Username));
            if (isUserAlreadyExists) {
                return BadRequest($"Sorry user with this username: '{model.Username}' already exists");
            }
            var role = "Admin";
            var userId = await _mediator.Send(new CreateUserCommand(model.FirstName, model.LastName, model.Username,
                model.Password, model.Email, model.PhoneNumber, role));
            var token = CreateToken(model.Username, role);
            return Ok(new {Token = token});
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model) 
        {
            var response = await _mediator.Send(new ValidateLoginQuery(model.Login, model.Password));
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