using Microsoft.AspNetCore.Mvc;
using HospitalApp.Data;
using HospitalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly HospitalContext _context;

        public UsersController(HospitalContext context)
        {
            _context = context;
        }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User newUser)
    {
        if (newUser == null)
        {
            return BadRequest("User data is null.");
        }

        if (!ModelState.IsValid)
        {
        
            return BadRequest(ModelState);
        }

        if (string.IsNullOrEmpty(newUser.Name) || 
            string.IsNullOrEmpty(newUser.Email) || 
            string.IsNullOrEmpty(newUser.PasswordHash))
        {
            return BadRequest("Invalid user data. All fields are required.");
        }


        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);
        if (existingUser != null)
        {
            return BadRequest("User already exists.");
        }

        try
        {
      
            newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.PasswordHash);

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginUser)
        {
            if (loginUser == null || string.IsNullOrEmpty(loginUser.Email) || string.IsNullOrEmpty(loginUser.PasswordHash))
            {
                return BadRequest(new { message = "Invalid login data." });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Email);


            if (user == null || !BCrypt.Net.BCrypt.Verify(loginUser.PasswordHash, user.PasswordHash))
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            return Ok(new { message = "Login successful!" });
        }
    }
}
