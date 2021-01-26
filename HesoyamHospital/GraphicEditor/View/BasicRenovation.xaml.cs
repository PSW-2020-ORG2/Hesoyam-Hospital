using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service.HospitalManagementService;
using Backend.Service.MedicalService;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for BasicRenovation.xaml
    /// </summary>
    public partial class BasicRenovation : Window
    {
        private readonly RoomService roomService;
        private readonly AppointmentSchedulingService appointmentSchedulingService;
        public readonly long APPOINTMENT_DURATION_MINUTES = 30;
        private Room room;
        private List<TimeInterval> alternativeTimeIntervals;
        private int minutes;
        public BasicRenovation(Room r)
        {
            InitializeComponent();
            appointmentSchedulingService = Backend.AppResources.getInstance().appointmentSchedulingService;
            roomService = Backend.AppResources.getInstance().roomService;
            room = r;
        }

        private void startDatePicker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                startDatePicker.IsDropDownOpen = true;
            }
        }

        private void endDatePicker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                endDatePicker.IsDropDownOpen = true;
            }
        }
        private void ButtonScheduleBasicRenovation_Click(object sender, RoutedEventArgs e)
        {

            DateTime startDate = startDatePicker.SelectedDate.Value;
            DateTime endDate = endDatePicker.SelectedDate.Value;
            TimeSpan varTime = endDate - startDate;
            minutes = (int)varTime.TotalMinutes;
            TimeInterval timeInterval = new TimeInterval(startDate, endDate);

            if (!roomService.IsRoomAvailableByTime(room, timeInterval))          
            {
                MessageWindow mw = new MessageWindow();
                mw.Title = "Room not available";
                mw.message.Content = "Room " + room.RoomNumber + " not available!";
                mw.ShowDialog();
                FillAlternativeTimeIntervals(timeInterval);
                searchAlternativeTerms.Visibility = Visibility.Visible;
            }
            else
                RoomRenovation(timeInterval);
        }


        private void FillAlternativeTimeIntervals(TimeInterval timeInterval)
        {
            alternativeTimeIntervals = new List<TimeInterval>();

            timeInterval.StartTime = timeInterval.EndTime;
            timeInterval.EndTime = timeInterval.StartTime.AddMinutes(minutes);
            TimeInterval time = new TimeInterval(timeInterval.StartTime, timeInterval.EndTime);

            if (roomService.IsRoomAvailableByTime(room, time)) alternativeTimeIntervals.Add(time);
        
            searchAlternativeTerms.ItemsSource = alternativeTimeIntervals;
            searchAlternativeTerms.Columns[0].Visibility = Visibility.Hidden;
        }

        private void SearchAlternativeTerms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  
            TimeInterval selectedTimeInterval = (TimeInterval)searchAlternativeTerms.SelectedItem;
            RoomRenovation(selectedTimeInterval);
        }

        private void RoomRenovation(TimeInterval timeInterval)
        {
            Appointment appointmentRenovation = new Appointment(null, null, room, AppointmentType.renovation, timeInterval);
            appointmentSchedulingService.Create(appointmentRenovation);
            MessageWindow ms = new MessageWindow();
            ms.Title = "Scheduled renovation";
            ms.message.Content = descriptioOfRenovation.Text + " is scheduled in room " + room.RoomNumber;
            ms.ShowDialog();
        }
    }
}
