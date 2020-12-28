using Xunit;
using System.Linq;
using Shouldly;
using Moq;
using System;
using System.Collections.Generic;
using Backend.Service.HospitalManagementService;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Model.PatientModel;
using GraphicEditor;
using Backend.Util;

namespace GraphicEditorTests.Unit
{
    public class AdvancedSearchForAppointmentsTests
    {

        [Fact]
        public void Get_all_rooms()
        {
            var stubRoomRepository = CreateStubRoomRepository();
            var stubAppointmentRepository = CreateStubAppointmentRepository();
            RoomService roomService = new RoomService(stubRoomRepository.Object, stubAppointmentRepository.Object);
            List<Room> allRooms = (List<Room>)roomService.GetAll();
            allRooms.ShouldNotBeEmpty();
        }

        [Fact]
        public void Get_available_rooms_by_date()
        {
            var stubRoomRepository = CreateStubRoomRepository();
            var stubAppointmentRepository = CreateStubAppointmentRepository();
            RoomService roomService = new RoomService(stubRoomRepository.Object, stubAppointmentRepository.Object);
            List<Room> availableRooms = (List<Room>)roomService.GetAvailableRoomsByDate(new TimeInterval(new DateTime(2021, 1, 1,8,30,0), new DateTime(2021, 1, 1,9,0,0)));
            availableRooms.ShouldNotBeEmpty();

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
            var stubAppointmentRepository = new Mock<IAppointmentRepository>();
            List<Appointment> appointments = new List<Appointment>();
            Appointment appointment1 = new Appointment();
            Appointment appointment2 = new Appointment();
            Appointment appointment3 = new Appointment();
            Appointment appointment4 = new Appointment();
            stubAppointmentRepository.Setup(m => m.GetAppointmentsByTime(new TimeInterval(new DateTime(2021,1,1), new DateTime(2021,2,2)))).Returns(appointments);
            return stubAppointmentRepository;
        }
    }
}
