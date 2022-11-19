using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.Models
{
    public class Doctors
    {
        public int DoctorsId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        // add nullable child ref to Product model
        public List<Booking>? Bookings { get; set; }
    }
}
