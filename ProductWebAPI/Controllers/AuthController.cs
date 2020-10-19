using DemoDAL.DAL.Models;
using DemoDAL.DAL.Services;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Infrastructure;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _service;
        private readonly TokenService _tokenService;

        public AuthController(AuthService service, TokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] User user)
        {
            _service.Register(user);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] User user)
        {
            user = _service.Login(user);
            if (user is null)
                return Unauthorized();

            user.Token = _tokenService.GenerateToken(user);
            return Ok(user);
        }
    }
}
