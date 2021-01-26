using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service.HospitalManagementService;
using Backend.Service.MedicalService;
using Backend.Util;
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

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for ComplexRenovation.xaml
    /// </summary>
    public partial class ComplexRenovation : Window
    {
        private readonly RoomService roomService;
        private Room room;
        private Room destinationRoom;
        private DateTime startDate;
        private DateTime endDate;
        public readonly long APPOINTMENT_DURATION_MINUTES = 30;
        private List<Room> availableRooms;
        private readonly AppointmentSchedulingService appointmentSchedulingService;
        private List<TimeInterval> alternativeTimeIntervals;
        public readonly int NUM_TERMS = 6;

        public ComplexRenovation(Room room1)
        {
            InitializeComponent();
            appointmentSchedulingService = Backend.AppResources.getInstance().appointmentSchedulingService;
            room = room1;

            roomService = Backend.AppResources.getInstance().roomService;

            List<Room> rooms = (List<Room>)roomService.GetAll();
            foreach(Room r in rooms)
            {
                if(room.Id == r.Id + 1 || room.Id == r.Id - 1)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Tag = r;
                    item.Content = r.Id;
                    chooseDestinationRoom.Items.Add(item);
                }
            }

            string t = "8:00";

            for (int i = 0; i <= 20; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                DateTime d = fromDatePicker.SelectedDate.Value;
                DateTime result = Convert.ToDateTime(t);
                DateTime dateTime = new DateTime(d.Year, d.Month, d.Day, result.Hour, result.Minute, 0);
                if (i > 0) dateTime = dateTime.AddMinutes(APPOINTMENT_DURATION_MINUTES);
                item.Tag = dateTime;
                item.Content = dateTime.ToShortTimeString();
                chooseFromTime.Items.Add(item);
                t = dateTime.ToShortTimeString();
            }

            string p = "8:00";

            for (int i = 0; i <= 20; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                DateTime d = toDatePicker.SelectedDate.Value;
                DateTime result = Convert.ToDateTime(p);
                DateTime dateTime = new DateTime(d.Year, d.Month, d.Day, result.Hour, result.Minute, 0);
                if (i > 0) dateTime = dateTime.AddMinutes(APPOINTMENT_DURATION_MINUTES);
                item.Tag = dateTime;
                item.Content = dateTime.ToShortTimeString();
                chooseToTime.Items.Add(item);
                p = dateTime.ToShortTimeString();
            }
        }

        private void FromDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                fromDatePicker.IsDropDownOpen = true;
            }
        }

        private void ToDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                toDatePicker.IsDropDownOpen = true;
            }
        }

        private void ChooseFromTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)chooseFromTime.SelectedItem;

            DateTime d = fromDatePicker.SelectedDate.Value;
            DateTime d2 = (DateTime)item.Tag;

            startDate = new DateTime(d.Year, d.Month, d.Day, d2.Hour, d2.Minute, 0);
        }

        private void ChooseToTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)chooseToTime.SelectedItem;

            DateTime d = toDatePicker.SelectedDate.Value;
            DateTime d2 = (DateTime)item.Tag;

            endDate = new DateTime(d.Year, d.Month, d.Day, d2.Hour, d2.Minute, 0);
        }

        private void buttonComplexRenovation_Click(object sender, RoutedEventArgs e)
        {
            DateTime startTime = startDate;
            DateTime endTime = endDate;
            TimeSpan varTime = (DateTime)endTime - (DateTime)startTime;
            int intMinutes = (int)varTime.TotalMinutes;
            TimeInterval timeInterval = new TimeInterval(startTime, endTime);

            if (chooseDestinationRoom != null)
            {
                if (chooseOption.SelectedIndex != 0)
                {
                    ComboBoxItem destRoom = (ComboBoxItem)chooseDestinationRoom.SelectedItem;
                    destinationRoom = (Room)destRoom.Tag;

                    availableRooms = (List<Room>)roomService.GetAvailableRoomsByDate(timeInterval);
                    bool isCurrentRoomAvailable = false;
                    bool isDestinationRoomAvailable = false;

                    foreach (Room r in availableRooms)
                    {
                        if (room.Id == r.Id)
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
                        mw.message.Content = "Current room not available!";
                        mw.ShowDialog();
                    }
                    else if (!isDestinationRoomAvailable)
                    {
                        MessageWindow mw = new MessageWindow();
                        mw.Title = "Room not available";
                        mw.message.Content = " Destination room not available!";
                        mw.ShowDialog();
                    }

                    else ScheduleComplexRenovation(timeInterval);

                    if (!isCurrentRoomAvailable || !isDestinationRoomAvailable)
                        FillAlternativeTimeIntervals(timeInterval, intMinutes);
                }

                else
                {
                    availableRooms = (List<Room>)roomService.GetAvailableRoomsByDate(timeInterval);
                    bool isCurrentRoomAvailable = false;

                    foreach (Room r in availableRooms)
                    {
                        if (room.Id == r.Id)
                        {
                            isCurrentRoomAvailable = true;
                            break;
                        }
                    }

                    if (!isCurrentRoomAvailable)
                    {
                        MessageWindow mw = new MessageWindow();
                        mw.Title = "Room not available";
                        mw.message.Content = "Current room not available!";
                        mw.ShowDialog();
                    }

                    else ScheduleComplexRenovation(timeInterval);


                    if (!isCurrentRoomAvailable)
                        FillAlternativeTimeIntervals(timeInterval, intMinutes);
                }
            }
        }

        private void ScheduleComplexRenovation(TimeInterval timeInterval)
        {
            Appointment appointmentRenovation = new Appointment(null, null, null, AppointmentType.renovation, timeInterval);

            appointmentSchedulingService.Create(appointmentRenovation);
            MessageWindow mw = new MessageWindow();
            mw.Title = "Complex renovation";
            mw.message.Content = "Successfully complex renovation!";
            mw.ShowDialog();
        }

        private void FillAlternativeTimeIntervals(TimeInterval timeInterval, int minutes)
        {
            alternativeTimeIntervals = new List<TimeInterval>();
            
            timeInterval.StartTime = timeInterval.EndTime;
            timeInterval.EndTime = timeInterval.StartTime.AddMinutes(minutes);
            TimeInterval time = new TimeInterval(timeInterval.StartTime, timeInterval.EndTime);

            if (roomService.IsRoomAvailableByTime(room, time) && roomService.IsRoomAvailableByTime(destinationRoom, time))
            {
                alternativeTimeIntervals.Add(time);      
            }
 
            searchAlternativeTerms.ItemsSource = alternativeTimeIntervals;
            searchAlternativeTerms.Columns[0].Visibility = Visibility.Hidden;
        }

        private void chooseOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseDestinationRoom != null)
            {
                if (chooseOption.SelectedIndex == 0)
                {
                    chooseDestinationRoom.IsEnabled = false;
                }
                else
                {
                    chooseDestinationRoom.IsEnabled = true;
                }
            }
        }

        private void SearchAlternativeTerms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimeInterval selectedTimeInterval = (TimeInterval)searchAlternativeTerms.SelectedItem;
            ScheduleComplexRenovation(selectedTimeInterval);
        }

    }
}
