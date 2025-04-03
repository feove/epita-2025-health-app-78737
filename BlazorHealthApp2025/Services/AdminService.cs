using BlazorHealthApp2025.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorHealthApp2025.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }
        // Method to add a role to a user
        public async Task AddRoleToUser(ApplicationUser user, string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (roleExist)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }

        // Method to remove a role from a user
        public async Task RemoveRoleFromUser(ApplicationUser user, string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (roleExist)
            {
                await _userManager.RemoveFromRoleAsync(user, roleName);
            }
        }

        // Method to delete an appointment
    


        // Get all users
        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        // Get roles of a user
        public async Task<List<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
        public async Task DeleteAppointmentAsync(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }

}
