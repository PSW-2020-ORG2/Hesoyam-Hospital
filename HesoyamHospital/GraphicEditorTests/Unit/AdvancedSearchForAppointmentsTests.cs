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

namespace GraphicEditorTests.Unit
{
    public class AdvancedSearchForAppointmentsTests
    {

        [Fact]
        public void Get_all_rooms()
        {
            var stubAppointmentRepository = new Mock<IAppointmentRepository>();
            var stubRoomRepository = CreateStubRoomRepository();
            RoomService roomService = new RoomService(stubRoomRepository.Object, stubAppointmentRepository.Object);
            List<Room> allRooms = (List<Room>)roomService.GetAll();
            allRooms.ShouldNotBeEmpty();
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
    }
}
