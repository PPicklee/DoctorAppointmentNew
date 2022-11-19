using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DoctorAppointment.Models;

namespace DoctorAppointment.Data
{
    public class DoctorAppointmentContext:IdentityDbContext
    {
        public DoctorAppointmentContext(DbContextOptions<DoctorAppointmentContext> options) : base(options)
        {

        }
        public DbSet<DoctorAppointment.Models.Booking> Booking { get; set; }
        public DbSet<DoctorAppointment.Models.Doctors> Doctors { get; set; }
    }
}
