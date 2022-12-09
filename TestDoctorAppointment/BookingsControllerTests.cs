using DoctorAppointment.Controllers;
using DoctorAppointment.Data;
using DoctorAppointment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDoctorAppointment
{
    [TestClass]
    public class UnitTest1
    {
        // db and controller reference to project
        private DoctorAppointmentContext context;
        BookingsController controller;

        // set up code that runs automatically before each unit test
        [TestInitialize]
        public void TestInitialize()
        {
            // must instantiate in memory db to pass as a dependency when creating an instance of ProductsController
            var options = new DbContextOptionsBuilder<DoctorAppointmentContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            context = new DoctorAppointmentContext(options);

            // seed the db before passing it to controller
            var doctors = new Doctors {DoctorsId = 1, Name ="Dr.John" };
            context.Add(doctors);

            for (var i = 100; i < 111; i++)
            {
                var booking = new Booking
                {
                    BookingId = i,
                    FirstName = "Random FName",
                    LastName = "Random LName",
                    PhoneNumber = "4169999999",
                    OHIPNumber = 10000222+i,
                    Email = "randomEmail@gmail.com",
                    Gender = "X",
                    Date = "12/12/12",
                    DoctorsId = 1
                };
                context.Add(booking);
            }
            context.SaveChanges();

            controller = new BookingsController(context);
        }


        //Index
        [TestMethod]
        public void IndexLoadsBookings()
        {
            // act
            var result = (ViewResult)controller.Index().Result;
            List<Booking> model = (List<Booking>)result.Model;

            // assert
            CollectionAssert.AreEqual(context.Booking.ToList(), model);
        }
        //Details
        [TestMethod]
        public void DetailsValidIdLoadsView()
        {
            // act
            var result = (ViewResult)controller.Details(104).Result;

            // assert 
            Assert.AreEqual(context.Booking.Find(104), result.Model);
        }
        [TestMethod]
        public void DetailsNullIdLoadsError()
        {
            context.Booking = null;
            var result = (ViewResult)controller.Details(null).Result;

            // assert 
            Assert.AreEqual("404", result.ViewName);
        }
    }
}