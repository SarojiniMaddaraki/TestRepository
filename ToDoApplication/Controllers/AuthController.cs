using ToDoApplication.Model;
using ToDoApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtServices _jwtServices;

        public AuthController(JwtServices jwtServices)
        {
            _jwtServices = jwtServices;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if (login.UserName == "admin" && login.Password == "admin")
            {
                var token = _jwtServices.GenerateToken(login.UserName, "Admin");
                return Ok(new { Token = token });
            }

            // Example for a regular user
            if (login.UserName == "user1" && login.Password == "password")
            {
                var token = _jwtServices.GenerateToken(login.UserName, "User");
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
    }
}
