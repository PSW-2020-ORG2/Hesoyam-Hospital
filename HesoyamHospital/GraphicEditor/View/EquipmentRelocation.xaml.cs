using System;
using System.Collections.Generic;
using System.Globalization;
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
        public readonly long APPOINTMENT_DURATION_MINUTES = 30;
        private Room currentRoom;
        private Room destinationRoom;
        private InventoryItem inventoryItem;

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

            String t = "8:00";

            for (int i = 0; i <= 8; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                DateTime date = (DateTime)toDatePicker.SelectedDate;
                var result = Convert.ToDateTime(t);
                DateTime emptyAppointment = new DateTime(date.Year, date.Month, date.Day, result.Hour, result.Minute, 0);
                DateTime dateTime = emptyAppointment;
                if (i > 0) dateTime = dateTime.AddMinutes(APPOINTMENT_DURATION_MINUTES);
                string time = dateTime.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);
                item.Tag = dateTime;
                chooseTime.Items.Add(time);
                t = time;
            }
        }
       
        private void ButtonEquipmentRelocation_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)chooseEquipment.SelectedItem;
            ComboBoxItem destRoom = (ComboBoxItem)chooseDestinationRoom.SelectedItem;
            inventoryItem = (InventoryItem)item.Tag;
            currentRoom = roomService.GetByID(inventoryItem.RoomID);
            destinationRoom = (Room)destRoom.Tag;
            // MessageWindow mw = new MessageWindow();
            // mw.Title = destinationRoom.RoomNumber;
            // mw.message.Content = currentRoom.RoomNumber;
            // mw.ShowDialog();
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
