using Shouldly;
using System.Collections.Generic;
using Backend.Service.HospitalManagementService;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using Backend.Model.ManagerModel;
using Backend;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Moq;
using Xunit;

namespace GraphicEditorTests.Unit
{
    public class EquipmentRelocationTest
    {
        [Fact]
        public void Move_equipment()
        {
            InventoryService inventoryService = new InventoryService(null, CreateStubInventoryItemRepository(), null);
            InventoryItem inventoryItem = new InventoryItem(1, "sto", 3, 1, new Room(1));
            Room room2 = new Room(2);
            inventoryItem.Room = room2;
            inventoryItem.Room.ShouldBeSameAs(room2);
        }

        private IInventoryItemRepository CreateStubInventoryItemRepository()
        {
            var stubInventoryItemRepository = new Mock<IInventoryItemRepository>();
            var items = new List<InventoryItem>();

            InventoryItem item1 = new InventoryItem(1,"stolica",6,5,new Room(1));
            InventoryItem item2 = new InventoryItem(2, "sto", 10, 5, new Room(3));
            InventoryItem item3 = new InventoryItem(2, "krevet", 6, 5, new Room(2));
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);

            stubInventoryItemRepository.Setup(m => m.GetAll()).Returns(items);
            return stubInventoryItemRepository.Object;
        }
    }

}
