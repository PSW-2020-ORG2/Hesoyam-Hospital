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
            int minutes = (int)varTime.TotalMinutes;
            TimeInterval timeInterval = new TimeInterval(startDate, endDate);

            if (roomService.IsRoomAvailableByTime(room, timeInterval))
            {
                Appointment appointmentRenovation = new Appointment(null, null, room, AppointmentType.renovation, timeInterval);
                appointmentSchedulingService.Create(appointmentRenovation);
                MessageWindow ms = new MessageWindow();
                ms.Title = "Scheduled renovation";
                ms.message.Content = descriptioOfRenovation.Text + " is scheduled in room " + room.Id;
                ms.ShowDialog();
            }
            else
            {
                MessageWindow mw = new MessageWindow();
                mw.Title = "Room not available";
                mw.message.Content = "Room " + room.RoomNumber + " not available!";
                mw.ShowDialog();
            }
        }

        private void SearchAlternativeTerms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
