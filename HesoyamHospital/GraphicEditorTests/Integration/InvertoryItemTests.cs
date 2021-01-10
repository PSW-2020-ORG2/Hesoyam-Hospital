using Xunit;
using System.Collections.Generic;
using Backend.Model.ManagerModel;
using Shouldly;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using Backend;
using Backend.Service.HospitalManagementService;

namespace GraphicEditorTests
{
    public class InvertoryItemTests
    {
        [Fact]
        public void Find_iventory_items_by_name()
        {

            InventoryItemRepository inventoryItemRepository = AppResources.getInstance().inventoryItemRepository;
            InventoryService inventoryService = new InventoryService(null, inventoryItemRepository, null);

            List<InventoryItem> items = (List<InventoryItem>)inventoryService.GetInventoryItemsByName("stolica");

            items.ShouldNotBeEmpty();
        }

        [Fact]
        public void Find_iventory_items_by_partial_name()
        {
            InventoryItemRepository inventoryItemRepository = AppResources.getInstance().inventoryItemRepository;
            InventoryService inventoryService = new InventoryService(null, inventoryItemRepository, null);

            List<InventoryItem> items = (List<InventoryItem>)inventoryService.GetInventoryItemsByName("t");

            items.ShouldNotBeEmpty();
        }

    }
}
