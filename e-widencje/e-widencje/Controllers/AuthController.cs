
using e_widencje.Models;
using e_widencje.Services;
using e_widencje.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;

namespace e_widencje.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        readonly ITokenService tokenService;
        public AuthController(ITokenService tokenService)
        {
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public object Login([FromBody] LoginModel login)
        {
            var mock = new Mock<MoqData>();
            var user = mock.Object.Auth(login);

            if (user != null)
            {
                var token = tokenService.GenerateAccessToken(login.Email);
                return Ok(new { accessToken = token });
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public object Register([FromBody] LoginModel login)
        {
            var mock = new Mock<MoqData>();
            mock.Object.Register(login);

            var token = tokenService.GenerateAccessToken(login.Email);
            return Ok(new { accessToken = token });
        }

        [Authorize("Bearer")]
        [HttpGet("user")]
        public IActionResult GetUser()
        {
            User user = null;
            var currentUser = HttpContext.User;
            var mock = new Mock<MoqData>();

            if (currentUser != null)
            {
                var authenticated = currentUser.Identity.IsAuthenticated;
                if (authenticated)
                {
                    user = mock.Object.Get(currentUser.Identity.Name);
                }
            }

            return user == null ? Unauthorized() : Ok(user);
        }
    }
}