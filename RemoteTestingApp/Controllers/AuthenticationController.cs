using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordHasherandJwtTokenProvider.Interfaces;
using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.Helpers;
using RemoteTestingApp.Core.Services.Interfaces;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.AuthRepository;
using System;
using System.Threading.Tasks;

namespace RemoteTestingApp.Controllers
{
    [Route("api/authentication/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IFileLogger _logger;
        private readonly IAuthenticationRepository _repo;
        private readonly ITokenProvider _provider;

        public AuthenticationController(IFileLogger logger, IAuthenticationRepository repo, ITokenProvider provider)
        {
            _logger = logger;
            _repo = repo;
            _provider = provider;
        }


        [HttpGet("GetRegisteredUser/{email}")]
        public async Task<IActionResult> GetRegisteredUser(string email)
        {
            var response = await _repo.GetRegisteredUser(email);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound("User bit Found");
            
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Registration(RegisterRequestDTO register)
        {
            if (await _repo.UserExistsAsync(register.Email)) return BadRequest("User Already Exists");
            var response = await _repo.RegisterAsync(register);
            if (response)
            {
                return CreatedAtAction("GetRegisteredUser",new { email = register.Email },"Registration Successful");
            }
            return BadRequest("An error occured");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> UserLogin(SigninRequestDTO signin)
        {
            var response = await _repo.LoginAsync(signin);
            if (response)
            {
                string jwtToken = _provider.GeneratedToken(
                   signin.Email, signin.Email, DateTime.Now.AddDays(2));
                return Ok(new LoginTokenData { 
                    Token = jwtToken,
                    ResponseMessage = "Login Successful"
                });
            }

            return Unauthorized("Login Failed");

        }
    }
}
