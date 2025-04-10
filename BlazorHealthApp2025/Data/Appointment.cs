using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorHealthApp2025.Data
{
    public class Appointment
    {
        public int Id { get; set; }

        
        public string PatientId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

       
   
        public string DoctorId { get; set; } = string.Empty;

        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; } = string.Empty;

        // IsConfirmed to track if doctor confirmed the appointment
        public bool IsConfirmed { get; set; } = false;
    }

}
