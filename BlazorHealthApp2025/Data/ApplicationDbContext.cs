using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorHealthApp2025.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<CalendarEntry> CalendarEntries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Doctor", NormalizedName = "DOCTOR" },
                new IdentityRole { Id = "3", Name = "Patient", NormalizedName = "PATIENT" }
            );

            // Relationship between User and Appointments
            builder.Entity<ApplicationUser>()
                .HasMany(a => a.Appointments)
                .WithOne()
                .HasForeignKey(a => a.PatientId);

            // Relationship between CalendarEntry and Appointment
            builder.Entity<CalendarEntry>()
                .HasOne(c => c.Appointment)
                .WithMany()
                .HasForeignKey(c => c.AppointmentId);  // Fix here
        }
    }
}
