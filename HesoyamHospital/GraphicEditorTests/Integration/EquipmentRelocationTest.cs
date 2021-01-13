using Shouldly;
using System.Collections.Generic;
using Backend.Service.HospitalManagementService;
using Backend.Model.ManagerModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Moq;
using Xunit;
using Backend;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;

namespace GraphicEditorTests.Integration
{
    public class EquipmentRelocationTest
    {
        [Fact]
        public void Move_equipment()
        {
            InventoryItemRepository inventoryItemRepository = AppResources.getInstance().inventoryItemRepository;
            InventoryService inventoryService = new InventoryService(null, inventoryItemRepository, null);
            List<InventoryItem> items = (List<InventoryItem>)inventoryService.GetInventoryItemsByName("stolica");
            InventoryItem inventoryItem = items[0];
            inventoryItem.RoomID = 205;
            
            inventoryService.UpdateInventoryItem(inventoryItem);
            
            inventoryItem.RoomID.ShouldBe(205);
        }

    }

}
