using Backend.DTOs;
using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Service.MedicalService;
using Backend.Util;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GraphicEditorTests.Unit
{
    public class ScheduleEmergencyAppointmentTests
    {
        [Fact]
        public void Find_term_for_emergency_appointment()
        {
            AppointmentSchedulingService appointmentSchedulingService = new AppointmentSchedulingService(CreateStubDoctorRepository(), CreateStubAppointmentRepository().Object);
            PriorityIntervalDTO dto = new PriorityIntervalDTO(DateTime.Today, DateTime.Today, null, false);
            PriorityIntervalDTO term = appointmentSchedulingService.GetAvailableTermsForEmergencyExamination(dto, DoctorType.GENERAL_PRACTITIONER);
            DateTime start = DateTime.Now.AddMinutes(30);
            term.StartTime.ShouldBeLessThan(start);
        }
        [Fact]
        public void Is_term_in_next_30_minutes()
        {
            AppointmentSchedulingService appointmentSchedulingService = new AppointmentSchedulingService(CreateStubDoctorRepository(), CreateStubAppointmentRepository().Object);
            List<PriorityIntervalDTO> intervals = new List<PriorityIntervalDTO>();
            Room room1 = new Room(1);
            Doctor doctor1 = new Doctor(101, null, "ivan", "ivan123", new DateTime(2017, 05, 13), "Ivan", "Ivanovic", "", "3010967800155", Sex.MALE, new DateTime(1967, 10, 30), null, null, "", "", "ivan.ivanovic67@gmail.com", "", new TimeTable(), null, room1, DoctorType.GENERAL_PRACTITIONER);
            PriorityIntervalDTO dto1 = new PriorityIntervalDTO(DateTime.Now, DateTime.Now.AddMinutes(30), doctor1.Name,false);
            PriorityIntervalDTO dto2 = new PriorityIntervalDTO(DateTime.Now.AddMinutes(60), DateTime.Now.AddMinutes(90), doctor1.Name,false);
            intervals.Add(dto1);
            intervals.Add(dto2);
            PriorityIntervalDTO term = appointmentSchedulingService.FindTermInNext30Minutes(intervals);
            term.ShouldBe(dto1);

        }

        private Mock<IAppointmentRepository> CreateStubAppointmentRepository()
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
            stubAppointmentRepository.Setup(m => m.GetAppointmentsByTime(new TimeInterval(DateTime.Today, DateTime.Today))).Returns(appointments);
            return stubAppointmentRepository;
        }

        private IDoctorRepository CreateStubDoctorRepository()
        {
            var stubDoctorRepository = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();
            List<Shift> shifts1 = new List<Shift>();
            ShiftType shiftType = new ShiftType(1, "shift1", new DateTime(2021,1,1,5,0,0), new DateTime(2021, 1, 30, 22, 0, 0));
            Shift shift1 = new Shift(1, DateTime.Today, shiftType, new List<Appointment>());
            shifts1.Add(shift1);
            TimeTable timeTable1 = new TimeTable(1, shifts1);
            Room room1 = new Room(101);
            Doctor doctor1 = new Doctor(101, null, "ivan", "ivan123", new DateTime(2017, 05, 13), "Ivan", "Ivanovic", "", "3010967800155", Sex.MALE, new DateTime(1967, 10, 30), null, null, "", "", "ivan.ivanovic67@gmail.com", "", timeTable1, null, room1, DoctorType.GENERAL_PRACTITIONER);
            doctors.Add(doctor1);
            stubDoctorRepository.Setup(m => m.GetDoctorByType(DoctorType.GENERAL_PRACTITIONER)).Returns(doctors);
            return stubDoctorRepository.Object;
        }
    }
}
