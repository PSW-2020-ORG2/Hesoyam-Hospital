using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.UsersRepository;
using Backend.Service.HospitalManagementService;
using Backend.Service.MedicalService;
using Backend.Service.UsersService;
using Backend.Util;
using GraphicEditor;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Xunit;

namespace GraphicEditorTests.Unit
{
    public class ScheduleAppointmentTest
    {
        [Fact]
        public void Schedule_appointment()
        {
            AppointmentSchedulingService appointmentSchedulingService = new AppointmentSchedulingService(CreateStubDoctorRepository(), CreateStubAppointmentRepository());
            Patient patient =  new Patient(103);
            Room firstAvailableRoom = new Room(103);
            List<Shift> shifts = new List<Shift>();
            Doctor doctor = new Doctor(101, null, "ivan", "ivan123", new DateTime(2017, 05, 13), "Ivan", "Ivanovic", "", "3010967800155", Sex.MALE, new DateTime(1967, 10, 30), null, null, "", "", "ivan.ivanovic67@gmail.com", "", new TimeTable(1, shifts), null, firstAvailableRoom, DoctorType.GENERAL_PRACTITIONER);
           
            Appointment appointment = appointmentSchedulingService.SaveAppointment(new Appointment(doctor, patient, firstAvailableRoom, AppointmentType.checkup, new TimeInterval(new DateTime(2021, 1, 1, 10, 0, 0), new DateTime(2021, 1, 1, 10, 30, 0))));

            appointment.ShouldBeSameAs(appointment);
        }


        private IRoomRepository CreateStubRoomRepository()
        {
            var stubRoomRepository = new Mock<IRoomRepository>();
            var rooms = new List<Room>();
            Room room1 = new Room(101);
            Room room2 = new Room(102);
            Room room3 = new Room(103);
            rooms.Add(room1);
            rooms.Add(room2);
            stubRoomRepository.Setup(m => m.GetAll()).Returns(rooms);
            return stubRoomRepository.Object;
        }

        private IPatientRepository CreateStubPatientRepository()
        {   
            var stubPatientRepository = new Mock<IPatientRepository>();
            var patients = new List<Patient>();
            
            Patient patient1 = new Patient(103);
            Patient patient2 = new Patient(109);
            patients.Add(patient1);
            patients.Add(patient2);

            stubPatientRepository.Setup(m => m.GetByID(103)).Returns(patient1);
            return stubPatientRepository.Object;
        }

        private IAppointmentRepository CreateStubAppointmentRepository()
        {
            var stubAppointmentRepository = new Mock<IAppointmentRepository>();
            List<Appointment> appointments = new List<Appointment>();
            List<Shift> shifts1 = new List<Shift>();
            Shift shift1 = new Shift(1);
            Shift shift2 = new Shift(2);
            shifts1.Add(shift1);
            shifts1.Add(shift2);
            TimeTable timeTable1 = new TimeTable(1, shifts1);
            Room room1 = new Room(101);
            Room room2 = new Room(102);
            Room room3 = new Room(103);
            Doctor doctor = new Doctor(101, null, "ivan", "ivan123", new DateTime(2017, 05, 13), "Ivan", "Ivanovic", "", "3010967800155", Sex.MALE, new DateTime(1967, 10, 30), null, null, "", "", "ivan.ivanovic67@gmail.com", "", timeTable1, null, room2, DoctorType.GENERAL_PRACTITIONER);
            Patient patient1 = new Patient(103);
            Patient patient2 = new Patient(109);
            TimeInterval timeInterval1 = new TimeInterval(new DateTime(2021, 1, 1, 8, 30, 0), new DateTime(2021, 1, 1, 9, 0, 0));
            TimeInterval timeInterval2 = new TimeInterval(new DateTime(2021, 1, 1, 9, 30, 0), new DateTime(2021, 1, 1, 10, 0, 0));
            Appointment appointment1 = new Appointment(1, doctor, patient1, room1, AppointmentType.checkup, timeInterval1);
            Appointment appointment2 = new Appointment(2, doctor, patient2, room2, AppointmentType.checkup, timeInterval2);
            appointments.Add(appointment1);
            appointments.Add(appointment2);
           
            stubAppointmentRepository.Setup(m => m.GetAppointmentsByTime(new TimeInterval(new DateTime(2021, 1, 1, 8, 30, 0), new DateTime(2021, 1, 1, 12, 0, 0)))).Returns(appointments);
            return stubAppointmentRepository.Object;
        }

        private IDoctorRepository CreateStubDoctorRepository()
        {
            var stubDoctorRepository = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();
            List<Shift> shifts1 = new List<Shift>();
            List<Shift> shifts2 = new List<Shift>();
            Shift shift1 = new Shift(1);
            Shift shift2 = new Shift(2);
            shifts1.Add(shift1);
            shifts1.Add(shift2);
            
            Shift shift3 = new Shift(3);
            Shift shift4 = new Shift(4);
            Shift shift5 = new Shift(5);
            Shift shift6 = new Shift(6);
            shifts2.Add(shift3);
            shifts2.Add(shift4);
            shifts2.Add(shift5);
            shifts2.Add(shift6);

            TimeTable timeTable1 = new TimeTable(1, shifts1);
            TimeTable timeTabel2 = new TimeTable(2, shifts2);
            Room room1 = new Room(101);
            Room room2 = new Room(102);
            Doctor doctor1 = new Doctor(101, null, "ivan", "ivan123", new DateTime(2017, 05, 13), "Ivan", "Ivanovic", "", "3010967800155", Sex.MALE, new DateTime(1967, 10, 30), null, null, "", "", "ivan.ivanovic67@gmail.com", "", timeTable1, null, room2, DoctorType.GENERAL_PRACTITIONER);
            Doctor doctor2 = new Doctor(102, null, "sanja", "sanja123", new DateTime(2016, 10, 10), "Sanja", "Vukovic", "", "1010972100102", Sex.FEMALE, new DateTime(1977, 10, 10), null, null, "", "064/221-58-40", null, null, timeTabel2, null, room1, DoctorType.GENERAL_PRACTITIONER);
            doctors.Add(doctor1);
            doctors.Add(doctor2);
          
            stubDoctorRepository.Setup(m => m.GetAll()).Returns(doctors);
            return stubDoctorRepository.Object;
        }


       public static IEnumerable<object[]> Data =>
       new List<object[]>
       {
            new object[] { 103, 101, 111},
       };
    }
}
