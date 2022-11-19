using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        public int OHIPNumber { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Date { get; set; }

        // Parent Category
        [Display(Name = "Doctors")]
        public int DoctorsId { get; set; }

        // Parent ref for auto-joins
        public Doctors? Doctors { get; set; }

    }
}
