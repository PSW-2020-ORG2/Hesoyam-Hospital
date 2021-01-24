using Appointments.DTOs;
using Appointments.Mappers;
using Appointments.Model;
using Appointments.Repository.Abstract;
using Appointments.Service;
using Appointments.Service.Abstract;
using Appointments.Util;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WebApplicationTests.Unit.Appointments
{
    public class ObserveAppointmentsTests
    {
        [Fact]
        public void Get_accurate_count_of_appointments()
        {
            AppointmentService service = new AppointmentService(CreateStubRepository(), null);

            List<Appointment> appointments = service.GetAllByPatient(1).ToList();

            appointments.Count.ShouldBeEquivalentTo(1);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Get_accurate_appointment_status(long patientId, AppointmentState expectedState)
        {
            AppointmentService service = new AppointmentService(CreateStubRepository(), null);

            List<Appointment> appointments = service.GetAllByPatient(patientId).ToList();

            AppointmentMapper.AppointmentToAppointmentForObservationDto(appointments[0], CreateStubRequestSender()).AppointmentState.ShouldBeEquivalentTo(expectedState.ToString());
        }

        private static IAppointmentRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            List<Appointment> appointments = new List<Appointment>();

            Appointment a1 = new Appointment(0);
            a1.DoctorInAppointmentId = 0;
            a1.TimeInterval = new TimeInterval(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1).AddMinutes(30));
            a1.Canceled = false;
            a1.PatientId = 1;
            appointments.Add(a1);

            Appointment a2 = new Appointment(1);
            a2.DoctorInAppointmentId = 1;
            a2.TimeInterval = new TimeInterval(DateTime.Now.AddMinutes(-10), DateTime.Now.AddMinutes(20));
            a2.Canceled = false;
            a2.PatientId = 2;
            appointments.Add(a2);

            Appointment a3 = new Appointment(2);
            a3.DoctorInAppointmentId = 2;
            a3.TimeInterval = new TimeInterval(DateTime.Now.AddMinutes(60), DateTime.Now.AddMinutes(90));
            a3.Canceled = false;
            a3.PatientId = 3;
            appointments.Add(a3);

            Appointment a4 = new Appointment(3);
            a4.DoctorInAppointmentId = 3;
            a4.TimeInterval = new TimeInterval(DateTime.Now.AddMinutes(60), DateTime.Now.AddMinutes(90));
            a4.Canceled = true;
            a4.PatientId = 4;
            appointments.Add(a4);

            stubRepository.Setup(r => r.GetAll()).Returns(appointments);

            return stubRepository.Object;
        }

        private static IHttpRequestSender CreateStubRequestSender()
        {
            var stubRequestSender = new Mock<IHttpRequestSender>();

            return stubRequestSender.Object;
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 1, AppointmentState.FINISHED },
            new object[] { 2, AppointmentState.IN_PROGRESS },
            new object[] { 3, AppointmentState.INCOMING },
            new object[] { 4, AppointmentState.CANCELLED }
        };
    }
}
