using Microsoft.EntityFrameworkCore;
using HospitalApp.Models;

namespace HospitalApp.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        // Add other DbSets for your models like Doctors, Appointments, etc.
    }
}
