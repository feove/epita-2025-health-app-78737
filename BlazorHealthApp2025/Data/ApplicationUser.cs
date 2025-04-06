using Microsoft.AspNetCore.Identity;

namespace BlazorHealthApp2025.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; } = "Patient";  
        public DateTime? TempAppointmentDate { get; set; }
        public string TempAppointmentTime { get; set; } = string.Empty;
        public string TempPatientId { get; set; } = string.Empty;
        public string TempDoctorId { get; set; } = string.Empty;
        public string TempDoctorName { get; set; } = string.Empty;
        public ICollection<Appointment>? Appointments { get; set; }

         public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool ConfirmedByDoctor { get; set; } = false;
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
