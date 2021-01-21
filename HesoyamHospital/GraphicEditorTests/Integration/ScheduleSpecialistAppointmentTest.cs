using Backend;
using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using Backend.Service.HospitalManagementService;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GraphicEditorTests.Integration
{
    public class ScheduleSpecialistAppointmentTest
    {   /*
        [Fact]
        public void Find_room_with_equipment()
        {
            InventoryItemRepository inventoryItemRepository = AppResources.getInstance().inventoryItemRepository;
            InventoryService inventoryService = new InventoryService(null, inventoryItemRepository, null);
            List<Room> rooms = new List<Room>();
            Room room1 = new Room(100);
            Room room2 = new Room(101);
            Room room3 = new Room(102);
            Room room4 = new Room(209);
            rooms.Add(room1);
            rooms.Add(room2);
            rooms.Add(room3);
            rooms.Add(room4);
            var items = new List<string>();
            items.Add("zavoj");
            items.Add("stetoskop");
            Room room = inventoryService.FindAvailableRoomWithEquipment(rooms, items);
            long id = room.Id;
            id.ShouldBe(209);
        }*/
    }
}
