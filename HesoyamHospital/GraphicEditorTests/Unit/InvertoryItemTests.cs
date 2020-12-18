using System;
using Xunit;
using GraphicEditor.Service;
using Backend.Model.UserModel;
using System.Collections.Generic;
using System.Text;
using Backend.Model.ManagerModel;
using System.Windows.Input;

namespace GraphicEditorTests
{
    public class InvertoryItemTests
    {
        [Fact]
        public void find_iventory_items_by_name()
        {
             List<InventoryItem> items = (List<InventoryItem>)Backend.AppResources.getInstance().inventoryService.GetInventoryItemsByName("stolica");
             Assert.NotEmpty(items);
        }

        [Fact]
        public void find_iventory_items_by_partial_name()
        {
            List<InventoryItem> items = (List<InventoryItem>)Backend.AppResources.getInstance().inventoryService.GetInventoryItemsByName("s");
            Assert.NotEmpty(items);
        }

    }
}
