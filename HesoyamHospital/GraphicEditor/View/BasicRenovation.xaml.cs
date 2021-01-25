using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service.HospitalManagementService;
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
    /// Interaction logic for BasicRenovation.xaml
    /// </summary>
    public partial class BasicRenovation : Window
    {
        private readonly RoomService roomService;
        public readonly long APPOINTMENT_DURATION_MINUTES = 30;
        private Room room;
        public BasicRenovation(Room r)
        {
            InitializeComponent();
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

            DateTime starDate = startDatePicker.SelectedDate.Value;
            DateTime endDate = endDatePicker.SelectedDate.Value;
            TimeInterval timeInterval = new TimeInterval(starDate, endDate);

            if (roomService.IsRoomAvailableByTime(room, timeInterval))
            {
                Appointment appointmentRenovation = new Appointment(null, null, room, AppointmentType.renovation, timeInterval);

                MessageWindow ms = new MessageWindow();
                ms.Title = "Scheduled renovation";
                ms.message.Content = descriptioOfRenovation.Text + " is scheduled in room " + room.Id;
                ms.ShowDialog();
            }
        }

        private void SearchAlternativeTerms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
