using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Util;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using WebApplication.Appointments;
using WebApplication.Appointments.DTOs;
using WebApplication.Appointments.Service;
using Xunit;

namespace WebApplicationTests.Unit.Appointments
{
    public class ObserveAppointmentsTests
    {
        [Fact]
        public void Get_accurate_count_of_appointments()
        {
            AppointmentService service = new AppointmentService(CreateStubRepository(), null, null);

            IEnumerable<Appointment> appointments = service.GetAllByPatient(0);

            ((List<Appointment>)appointments).Count.ShouldBeEquivalentTo(4);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Get_accurate_appointment_status(long patientId, AppointmentState expectedState)
        {
            AppointmentService service = new AppointmentService(CreateStubRepository(), null, null);

            List<Appointment> appointments = (List<Appointment>)service.GetAllByPatient(patientId);

            AppointmentMapper.AppointmentToAppointmentForObservationDto(appointments[0]).AppointmentState.ShouldBeEquivalentTo(expectedState.ToString());
        }

        private static IPatientRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPatientRepository>();
            Patient patient1 = new Patient(0);
            Patient patient2 = new Patient(1);
            Patient patient3 = new Patient(2);
            Patient patient4 = new Patient(3);
            Patient patient5 = new Patient(4);

            Appointment a1 = new Appointment(0);
            Doctor d1 = new Doctor(0)
            {
                Name = "Pera",
                Surname = "Peric",
                Specialisation = DoctorType.CARDIOLOGIST,
                Office = new Room("C101", false, 1, RoomType.EXAMINATION)
            };
            a1.DoctorInAppointment = d1;
            a1.TimeInterval = new TimeInterval(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1).AddMinutes(30));
            a1.Canceled = false;
            patient1.Appointments = new List<Appointment>();
            patient2.Appointments = new List<Appointment>();
            patient1.Appointments.Add(a1);
            patient2.Appointments.Add(a1);

            Appointment a2 = new Appointment(1);
            Doctor d2 = new Doctor(1)
            {
                Name = "Marko",
                Surname = "Markovic",
                Specialisation = DoctorType.DERMATOLOGIST,
                Office = new Room("D250", false, 2, RoomType.EXAMINATION)
            };
            a2.DoctorInAppointment = d2;
            a2.TimeInterval = new TimeInterval(DateTime.Now.AddMinutes(-10), DateTime.Now.AddMinutes(20));
            a2.Canceled = false;
            patient1.Appointments.Add(a2);
            patient3.Appointments = new List<Appointment>();
            patient3.Appointments.Add(a2);

            Appointment a3 = new Appointment(2);
            Doctor d3 = new Doctor(2)
            {
                Name = "Ivan",
                Surname = "Petrovic",
                Specialisation = DoctorType.ENDOCRINIOLOGIST,
                Office = new Room("E200", false, 2, RoomType.EXAMINATION)
            };
            a3.DoctorInAppointment = d3;
            a3.TimeInterval = new TimeInterval(DateTime.Now.AddMinutes(60), DateTime.Now.AddMinutes(90));
            a3.Canceled = false;
            patient1.Appointments.Add(a3);
            patient4.Appointments = new List<Appointment>();
            patient4.Appointments.Add(a3);

            Appointment a4 = new Appointment(3);
            a4.DoctorInAppointment = d3;
            a4.TimeInterval = new TimeInterval(DateTime.Now.AddMinutes(60), DateTime.Now.AddMinutes(90));
            a4.Canceled = true;
            patient1.Appointments.Add(a4);
            patient5.Appointments = new List<Appointment>();
            patient5.Appointments.Add(a4);

            stubRepository.Setup(r => r.GetByID(0)).Returns(patient1);
            stubRepository.Setup(r => r.GetByID(1)).Returns(patient2);
            stubRepository.Setup(r => r.GetByID(2)).Returns(patient3);
            stubRepository.Setup(r => r.GetByID(3)).Returns(patient4);
            stubRepository.Setup(r => r.GetByID(4)).Returns(patient5);

            return stubRepository.Object;
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
