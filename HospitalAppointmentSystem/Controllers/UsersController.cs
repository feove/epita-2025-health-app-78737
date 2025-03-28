using Microsoft.AspNetCore.Mvc;
using HospitalApp.Data;
using HospitalApp.Models;

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

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is invalid.");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
        }
    }
}
