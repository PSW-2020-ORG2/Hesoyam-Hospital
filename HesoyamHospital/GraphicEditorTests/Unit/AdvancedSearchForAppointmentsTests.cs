using Xunit;
using Shouldly;
using Moq;
using System;
using System.Collections.Generic;
using Backend.Service.HospitalManagementService;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Model.PatientModel;
using Backend.Util;
using Backend.Model.DoctorModel;
using Backend.Model.UserModel;

namespace GraphicEditorTests.Unit
{
    public class AdvancedSearchForAppointmentsTests
    {

        [Fact]
        public void Get_all_rooms()
        {
            var rooms = new List<Room>();
            Room room1 = new Room(1);
            Room room2 = new Room(2);
            Room room3 = new Room(3);
            Room room4 = new Room(4);
            rooms.Add(room1);
            rooms.Add(room2);
            rooms.Add(room3);
            rooms.Add(room4);
            var stubRoomRepository = CreateStubRoomRepository();
            var stubAppointmentRepository = CreateStubAppointmentRepository();
            RoomService roomService = new RoomService(stubRoomRepository.Object, stubAppointmentRepository.Object);
            List<Room> allRooms = (List<Room>)roomService.GetAll();
            allRooms.ShouldBe(rooms);
        }

        [Fact]
        public void Get_available_rooms_by_date()
        {
            var stubRoomRepository = CreateStubRoomRepository();
            var stubAppointmentRepository = CreateStubAppointmentRepository();
            var rooms = new List<Room>();
            Room room3 = new Room(3);
            Room room4 = new Room(4);

            rooms.Add(room3);
            rooms.Add(room4);
            RoomService roomService = new RoomService(stubRoomRepository.Object, stubAppointmentRepository.Object);
            List<Room> availableRooms = (List<Room>)roomService.GetAvailableRoomsByDate(new TimeInterval(new DateTime(2021, 1, 1,8,30,0), new DateTime(2021, 1, 1,9,0,0)));
            availableRooms.ShouldBe(rooms);

        }

        private Mock<IRoomRepository> CreateStubRoomRepository()
        { 
            var stubRoomRepository = new Mock<IRoomRepository>();
            var rooms = new List<Room>();
            Room room1 = new Room(1);
            Room room2 = new Room(2);
            Room room3 = new Room(3);
            Room room4 = new Room(4);
            rooms.Add(room1);
            rooms.Add(room2);
            rooms.Add(room3);
            rooms.Add(room4);
            stubRoomRepository.Setup(m => m.GetAll()).Returns(rooms);
            return stubRoomRepository;
        }

        private Mock<IAppointmentRepository> CreateStubAppointmentRepository()
        {
           // long id, Doctor doctor, Patient patient, Room room, AppointmentType appointmentType, TimeInterval timeInterval
            var stubAppointmentRepository = new Mock<IAppointmentRepository>();
            List<Appointment> appointments = new List<Appointment>();
           
            List<Shift> shifts = new List<Shift>();
            Doctor doctor = new Doctor("sanja", "sanja123", new DateTime(2016,10,10), "Sanja", "Vukovic", "", "1010972100102",Sex.FEMALE, new DateTime(1977,10,10), null, null,"","064/221-58-40",null, null, new TimeTable(1, shifts), null, null, DoctorType.GENERAL_PRACTITIONER);
            Patient patient = new Patient("ana", "ana123", new DateTime(2016, 10, 10), "Ana", "Markovic", "", "1111991715295", Sex.FEMALE, new DateTime(1991, 11, 11), null, null, "", "066/112-22-22", null, null, doctor,"1234156117");
            Room room1 = new Room(1);
            Room room2 = new Room(2);
            Room room3 = new Room(3);
            Room room4 = new Room(4);
            TimeInterval timeInterval1 = new TimeInterval(new DateTime(2021, 1, 1, 8, 30, 0), new DateTime(2021, 1, 1, 9, 0, 0));
            Appointment appointment1 = new Appointment(1, doctor, patient, room1, AppointmentType.checkup, timeInterval1);
            Appointment appointment2 = new Appointment(2, doctor, patient, room2, AppointmentType.checkup, timeInterval1);
            appointments.Add(appointment1);
            appointments.Add(appointment2);
            stubAppointmentRepository.Setup(m => m.GetAppointmentsByTime(new TimeInterval(new DateTime(2021,1,1,8,30,0), new DateTime(2021,1,1,9,0,0)))).Returns(appointments);
            return stubAppointmentRepository;
        }
    }
}
