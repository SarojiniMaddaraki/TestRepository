using GroceryApp.Model;
using GroceryApp.Service;
using GroceryApplication.DTOs;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;


namespace GroceryApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly UserService _userService;

        public AuthController(JwtService jwtService, UserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        // ✅ LOGIN
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _userService.GetUsers(0, 100)
                        .FirstOrDefault(x => x.Username == model.Username);

            if (user == null)
                return Unauthorized("Invalid credentials");

            // 🔐 VERIFY HASH
            bool isValid = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);

            if (!isValid)
                return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateToken(user.Username, "User");

            return Ok(new { token });
        }

        // ✅ REGISTER
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var user = new UserModel
            {
                Id = Guid.NewGuid(),
                Username = model.Username,
                Email = model.Email,
                Phone = model.Phone,
                Age = model.Age,

                // 🔥 IMPORTANT
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };

            _userService.AddUser(user);

            return Ok("User Registered Successfully");
        }
    }
}