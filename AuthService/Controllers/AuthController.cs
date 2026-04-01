using Microsoft.AspNetCore.Mvc;
using AuthService.Models;
using AuthService.Data;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        // Signup API
        [HttpPost("signup")]
        public IActionResult Signup(User user)
        {
            var existingUser = FakeDb.Users.FirstOrDefault(u => u.Email == user.Email);

            if (existingUser != null)
                return BadRequest("User already exists");

            user.Id = FakeDb.Users.Count + 1;
            FakeDb.Users.Add(user);

            return Ok("User registered successfully");
        }

        // Login API
        [HttpPost("login")]
        public IActionResult Login(LoginRequest login)
        {
            var user = FakeDb.Users.FirstOrDefault(u =>
                u.Email == login.Email && u.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            return Ok("Login successful");
        }
    }
}