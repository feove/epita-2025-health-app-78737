using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Models
{
   public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }

}
