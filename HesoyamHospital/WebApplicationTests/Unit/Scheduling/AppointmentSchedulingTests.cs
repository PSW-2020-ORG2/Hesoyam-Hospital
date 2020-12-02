using Backend.Model.PatientModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebApplication.Scheduling;
using WebApplication.Scheduling.Service;
using Xunit;

namespace WebApplicationTests.Unit.Scheduling
{
    public class AppointmentSchedulingTests
    {
        [Theory]
        [MemberData(nameof(AppointmentData))]
        public void Saving_appointment_to_database(AppointmentDTO dto, Times times)
        {
            var appointmentService = new Mock<IAppointmentSchedulingService>();
            var controller = new AppointmentController(appointmentService.Object);

            controller.SaveAppointment(dto);

            appointmentService.Verify(n => n.SaveAppointment(It.IsAny<Appointment>()), times);
        }
        public static IEnumerable<object[]> AppointmentData =>
           new List<object[]>
           {
                new object[] { new AppointmentDTO(), Times.Once()},
                new object[] { null, Times.Never() },
           };
    }
}
