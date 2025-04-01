using Microsoft.AspNetCore.Identity;

namespace BlazorHealthApp2025.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; } = "Patient";  // Default role is "Patient"
    }
}
