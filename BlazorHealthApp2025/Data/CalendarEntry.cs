using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorHealthApp2025.Data
{
    public class CalendarEntry
    {
        public int Id { get; set; }

        [Required]
        public string PatientId { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool IsConfirmed { get; set; } = false;

        [Required]
        [StringLength(200)]
        public string Notes { get; set; } = string.Empty;

     
        public int AppointmentId { get; set; }

      
        public Appointment? Appointment { get; set; }
    }
}
