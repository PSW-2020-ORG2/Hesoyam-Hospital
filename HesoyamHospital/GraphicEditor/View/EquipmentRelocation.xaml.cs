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
using Backend.Util;

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
        private List<Room> availableRooms;
        private DateTime date;
        private SearchService searchService;

        public EquipmentRelocation()
        {
            InitializeComponent();
            inventoryService = Backend.AppResources.getInstance().inventoryService;
            List<InventoryItem> inventories = (List<InventoryItem>)inventoryService.GetInventoryItems();
            roomService = Backend.AppResources.getInstance().roomService;
            List<Room> rooms = (List<Room>)roomService.GetAll();
            searchService = new SearchService();

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

            for (int i = 0; i <= 20; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                DateTime date = (DateTime)toDatePicker.SelectedDate.Value;
                DateTime result = Convert.ToDateTime(t);
                DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, result.Hour, result.Minute, 0);
                if (i > 0) dateTime = dateTime.AddMinutes(APPOINTMENT_DURATION_MINUTES);
                item.Tag = dateTime;
                item.Content = dateTime.ToShortTimeString();
                chooseTime.Items.Add(item);
                t = dateTime.ToShortTimeString();
            }
        }

        private void chooseTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)chooseTime.SelectedItem;
            DateTime d2 = (DateTime)item.Tag;
            DateTime d = (DateTime)toDatePicker.SelectedDate.Value;
            date = new DateTime(d.Year, d.Month, d.Day, d2.Hour, d2.Minute, 0);
        }

        private void ButtonEquipmentRelocation_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)chooseEquipment.SelectedItem;
            ComboBoxItem destRoom = (ComboBoxItem)chooseDestinationRoom.SelectedItem;
            inventoryItem = (InventoryItem)item.Tag;
            currentRoom = roomService.GetByID(inventoryItem.RoomID);
            destinationRoom = (Room)destRoom.Tag;

            DateTime startTime = date;
            DateTime endTime = date.AddMinutes(APPOINTMENT_DURATION_MINUTES);
            TimeInterval timeInterval = new TimeInterval(startTime, endTime);

            availableRooms = (List<Room>)roomService.GetAvailableRoomsByDate(timeInterval);
            bool isCurrentRoomAvailable = false;
            bool isDestinationRoomAvailable = false;

            foreach (Room r in availableRooms)
            {
                if (currentRoom.Id == r.Id)
                {
                    isCurrentRoomAvailable = true;
                    break;
                }
            }

            foreach (Room r in availableRooms)
            {
                if (destinationRoom.Id == r.Id)
                {
                    isDestinationRoomAvailable = true;
                    break;
                }
            }
            if (!isCurrentRoomAvailable)
            {
                MessageWindow mw = new MessageWindow();
                mw.Title = "Room not available";
                mw.message.Content = "Room " + currentRoom.Id + " not available!";
                mw.ShowDialog();
                MapLocation mapLocation = searchService.GetLocationByRoomName(currentRoom.RoomNumber);
                searchService.DisplayResults(mapLocation);
            }
            else if (!isDestinationRoomAvailable)
            {
                MessageWindow mw = new MessageWindow();
                mw.Title = "Room not available";
                mw.message.Content = "Room " + destinationRoom.Id + " not available!";
                mw.ShowDialog();
                MapLocation mapLocation = searchService.GetLocationByRoomName(destinationRoom.RoomNumber);
                searchService.DisplayResults(mapLocation);
            }
            else
            {
                MessageWindow mw = new MessageWindow();
                mw.Title = "Equipment relocation";
                mw.message.Content = "Successfully equipment relocation!";
                mw.ShowDialog();
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
