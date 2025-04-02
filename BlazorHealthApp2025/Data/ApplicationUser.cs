using Microsoft.AspNetCore.Identity;

namespace BlazorHealthApp2025.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; } = "Patient";  
    }

    public class ApplicationDbContextSeed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roleNames = new[] { "Admin", "Patient", "Doctor" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }

}
