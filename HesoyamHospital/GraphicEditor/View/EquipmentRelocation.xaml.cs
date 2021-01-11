using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Backend.Model.ManagerModel;
using Backend.Model.UserModel;
using Backend.Service.HospitalManagementService;

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for EquipmentRelocation.xaml
    /// </summary>
    public partial class EquipmentRelocation : Window
    {
        private readonly InventoryService inventoryService;
        private readonly RoomService roomService;

        public EquipmentRelocation()
        {
            InitializeComponent();
            inventoryService = Backend.AppResources.getInstance().inventoryService;
            List<InventoryItem> inventories = (List<InventoryItem>)inventoryService.GetInventoryItems();
            roomService = Backend.AppResources.getInstance().roomService;
            List<Room> rooms = (List<Room>)roomService.GetAll();

            foreach (InventoryItem inventoryItem in inventories)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Tag = inventoryItem;
                item.Content = inventoryItem.Name + " - " + "Room location:" + " " + inventoryItem.RoomID;
                chooseEquipment.Items.Add(item);
            }

            foreach (Room room in rooms)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Tag = room;
                item.Content = room.Id;
                chooseDestinationRoom.Items.Add(item);
            }

        }
        private void ToDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                toDatePicker.IsDropDownOpen = true;
            }
        }

        private void buttonEquipmentRelocation_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
