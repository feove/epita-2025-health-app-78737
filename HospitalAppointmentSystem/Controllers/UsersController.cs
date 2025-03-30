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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginUser)
        {
            if (loginUser == null || string.IsNullOrEmpty(loginUser.Email) || string.IsNullOrEmpty(loginUser.PasswordHash))
            {
                return BadRequest(new { message = "Invalid login data." });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Email);

            if (user == null || user.PasswordHash != loginUser.PasswordHash)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            return Ok(new { message = "Login successful!" });
        }
    }
}
