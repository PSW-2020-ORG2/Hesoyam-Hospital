using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Service.MedicalService;
using Backend.Service.UsersService;
using Backend.Util;
using GraphicEditor;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace GraphicEditorTests.Unit
{
    public class ScheduleAppointmentTest
    {
        [Fact]
        public void Schedule_appointment()
        {
            AppointmentSchedulingService appointmentSchedulingService = new AppointmentSchedulingService(CreateStubDoctorRepository(), CreateStubAppointmentRepository());
            DoctorService doctorService = new DoctorService(CreateStubDoctorRepository());
            List<Shift> shifts = new List<Shift>();
            Doctor doctor = new Doctor("sanja", "sanja123", new DateTime(2016, 10, 10), "Sanja", "Vukovic", "", "1010972100102", Sex.FEMALE, new DateTime(1977, 10, 10), null, null, "", "064/221-58-40", null, null, new TimeTable(1, shifts), null, null, DoctorType.GENERAL_PRACTITIONER);
            Room room = new Room(101, "examinationroom1", false, 1, RoomType.EXAMINATION);

            Appointment appointmentForPatient = appointmentSchedulingService.Create(new Appointment(doctor, new Patient("milan", "milan123", "Milan", "Milic", "", "101198210102", Sex.MALE, new DateTime(1982, 11, 10), null, null, null, "064/335-44-66", null, null, null, ""), room, AppointmentType.checkup, new TimeInterval(new DateTime(2021, 1, 1, 8, 30, 0), new DateTime(2021, 1, 1, 9, 0, 0))));

            appointmentForPatient.ShouldBeSameAs(appointmentForPatient);
        }

        private IAppointmentRepository CreateStubAppointmentRepository()
        {

            var stubAppointmentRepository = new Mock<IAppointmentRepository>();
            List<Appointment> appointments = new List<Appointment>();

            List<Shift> shifts = new List<Shift>();
            Doctor doctor = new Doctor("sanja", "sanja123", new DateTime(2016, 10, 10), "Sanja", "Vukovic", "", "1010972100102", Sex.FEMALE, new DateTime(1977, 10, 10), null, null, "", "064/221-58-40", null, null, new TimeTable(1, shifts), null, null, DoctorType.GENERAL_PRACTITIONER);
            Patient patient = new Patient("ana", "ana123", new DateTime(2016, 10, 10), "Ana", "Markovic", "", "1111991715295", Sex.FEMALE, new DateTime(1991, 11, 11), null, null, "", "066/112-22-22", null, null, doctor, "1234156117");
            Room room1 = new Room(1);
            Room room2 = new Room(2);
            Room room3 = new Room(3);
            Room room4 = new Room(4);
            TimeInterval timeInterval1 = new TimeInterval(new DateTime(2021, 1, 1, 8, 30, 0), new DateTime(2021, 1, 1, 9, 0, 0));
            Appointment appointment1 = new Appointment(1, doctor, patient, room1, AppointmentType.checkup, timeInterval1);
            Appointment appointment2 = new Appointment(2, doctor, patient, room2, AppointmentType.checkup, timeInterval1);
            appointments.Add(appointment1);
            appointments.Add(appointment2);
            stubAppointmentRepository.Setup(m => m.GetAppointmentsByTime(new TimeInterval(new DateTime(2021, 1, 1, 8, 30, 0), new DateTime(2021, 1, 1, 9, 0, 0)))).Returns(appointments);
            return stubAppointmentRepository.Object;
        }

        private IDoctorRepository CreateStubDoctorRepository()
        {
            var stubDoctorRepository = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();
            List<Shift> shifts = new List<Shift>();
            TimeInterval timeInterval1 = new TimeInterval(new DateTime(2021, 1, 1, 8, 30, 0), new DateTime(2021, 1, 1, 9, 0, 0));
            Doctor doctor = new Doctor(10, null, "sanja", "sanja123", new DateTime(2016, 10, 10), "Sanja", "Vukovic", "", "1010972100102", Sex.FEMALE, new DateTime(1977, 10, 10), null, null, "064/221-58-40", "", "", "", new TimeTable(1, shifts), null, new Room(101), DoctorType.GENERAL_PRACTITIONER);
            doctors.Add(doctor);

            stubDoctorRepository.Setup(m => m.GetAll()).Returns(doctors);
            return stubDoctorRepository.Object;
        }
    }
}
