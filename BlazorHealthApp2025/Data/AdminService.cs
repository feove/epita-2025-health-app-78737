using BlazorHealthApp2025.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorHealthApp2025.Services
{
    public class AdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
    }
}
