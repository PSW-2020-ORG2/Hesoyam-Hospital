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
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service.HospitalManagementService;
using Backend.Service.MedicalService;
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
        public readonly int NUM_TERMS = 6; 
        private Room currentRoom;
        private Room destinationRoom;
        private InventoryItem inventoryItem;
        private List<Room> availableRooms;
        private DateTime date;
        private SearchService searchService;
        private readonly AppointmentSchedulingService appointmentSchedulingService;
        private List<TimeInterval> alternativeTimeIntervals;

        public EquipmentRelocation()
        {
            InitializeComponent();
            inventoryService = Backend.AppResources.getInstance().inventoryService;
            List<InventoryItem> inventories = (List<InventoryItem>)inventoryService.GetInventoryItems();
            roomService = Backend.AppResources.getInstance().roomService; 
            appointmentSchedulingService = Backend.AppResources.getInstance().appointmentSchedulingService;
            List<Room> rooms = (List<Room>)roomService.GetAll();
            searchService = new SearchService();

            foreach (InventoryItem i in inventories)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Tag = i;
                item.Content = i.Name + " - " + "Room location:" + " " + i.RoomID;
                chooseEquipment.Items.Add(item);
            }

            foreach (Room room in rooms)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Tag = room;
                item.Content = room.Id;
                chooseDestinationRoom.Items.Add(item);
            }

            string t = "8:00";

            for (int i = 0; i <= 20; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                DateTime d = toDatePicker.SelectedDate.Value;
                DateTime result = Convert.ToDateTime(t);
                DateTime dateTime = new DateTime(d.Year, d.Month, d.Day, result.Hour, result.Minute, 0);
                if (i > 0) dateTime = dateTime.AddMinutes(APPOINTMENT_DURATION_MINUTES);
                item.Tag = dateTime;
                item.Content = dateTime.ToShortTimeString();
                chooseTime.Items.Add(item);
                t = dateTime.ToShortTimeString();
            }
        }

        private void ChooseTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)chooseTime.SelectedItem;

            DateTime d = toDatePicker.SelectedDate.Value; 
            DateTime d2 = (DateTime)item.Tag;
            
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
            else RelocationEquipment(timeInterval);
            

            if (!isCurrentRoomAvailable || !isDestinationRoomAvailable)
                FillAlternativeTimeIntervals(timeInterval);
            
        }

        private void FillAlternativeTimeIntervals(TimeInterval timeInterval)
        {
            alternativeTimeIntervals = new List<TimeInterval>();

            int counterTerms = 0;
            while (counterTerms <= NUM_TERMS)
            {
                timeInterval.StartTime = timeInterval.EndTime;
                timeInterval.EndTime = timeInterval.StartTime.AddMinutes(APPOINTMENT_DURATION_MINUTES);
                TimeInterval time = new TimeInterval(timeInterval.StartTime, timeInterval.EndTime);

                if (roomService.IsRoomAvailableByTime(currentRoom, time) && roomService.IsRoomAvailableByTime(destinationRoom, time))
                {
                    alternativeTimeIntervals.Add(time);
                    counterTerms++;   
                }
            }

            searchAlternativeTerms.ItemsSource = alternativeTimeIntervals;
            searchAlternativeTerms.Columns[0].Visibility = Visibility.Hidden;
        }

        private void RelocationEquipment(TimeInterval timeInterval)
        {
            Appointment appointmentRelocation1 = new Appointment(null, null, destinationRoom, AppointmentType.relocation, timeInterval);
            Appointment appointmentRelocation2 = new Appointment(null, null, currentRoom, AppointmentType.relocation, timeInterval);

            appointmentSchedulingService.Create(appointmentRelocation1);
            appointmentSchedulingService.Create(appointmentRelocation2);
            inventoryItem.RoomID = destinationRoom.Id;
            inventoryService.UpdateInventoryItem(inventoryItem);
            MessageWindow mw = new MessageWindow();
            mw.Title = "Equipment relocation";
            mw.message.Content = "Successfully equipment relocation!";
            mw.ShowDialog();
        }

        private void SearchAlternativeTerms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimeInterval selectedTimeInterval = (TimeInterval)searchAlternativeTerms.SelectedItem;
            RelocationEquipment(selectedTimeInterval);
        }

        private void ToDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                toDatePicker.IsDropDownOpen = true;
            }
        }
    }
}
