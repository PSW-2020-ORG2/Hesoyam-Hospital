﻿using Backend.Model.PatientModel;
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
        private List<Room> availableRooms;
        private DateTime startTime;
        private DateTime endTime;
        private int minutes;

        public BasicRenovation(Room r)
        {
            InitializeComponent();
            appointmentSchedulingService = Backend.AppResources.getInstance().appointmentSchedulingService;
            roomService = Backend.AppResources.getInstance().roomService;
            room = r;

            string t = "8:00";

            for (int i = 0; i <= 20; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                DateTime d1 = startDatePicker.SelectedDate.Value;
                DateTime result = Convert.ToDateTime(t);
                DateTime dateTime1 = new DateTime(d1.Year, d1.Month, d1.Day, result.Hour, result.Minute, 0);
                if (i > 0) dateTime1 = dateTime1.AddMinutes(APPOINTMENT_DURATION_MINUTES);
                item.Tag = dateTime1;
                item.Content = dateTime1.ToShortTimeString();
                chooseStartTime.Items.Add(item);
                t = dateTime1.ToShortTimeString();
            }

            string v = "8:00";

            for (int i = 0; i <= 20; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                DateTime d2 = endDatePicker.SelectedDate.Value;
                DateTime result = Convert.ToDateTime(v);
                DateTime dateTime2 = new DateTime(d2.Year, d2.Month, d2.Day, result.Hour, result.Minute, 0);
                if (i > 0) dateTime2 = dateTime2.AddMinutes(APPOINTMENT_DURATION_MINUTES);
                item.Tag = dateTime2;
                item.Content = dateTime2.ToShortTimeString();
                chooseEndTime.Items.Add(item);
                v = dateTime2.ToShortTimeString();
            }
        }

        private void StartDatePicker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                startDatePicker.IsDropDownOpen = true;
            }
        }

        private void EndDatePicker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                endDatePicker.IsDropDownOpen = true;
            }
        }
        private void ButtonScheduleBasicRenovation_Click(object sender, RoutedEventArgs e)
        { 
            TimeSpan varTime = endTime - startTime;
            minutes = (int)varTime.TotalMinutes;
            TimeInterval timeInterval = new TimeInterval(startTime, endTime);

            availableRooms = (List<Room>)roomService.GetAvailableRoomsByDate(timeInterval);
            bool isRoomAvailable = false;

            foreach(Room r in availableRooms)
                if(room.Id == r.Id)
                {
                    isRoomAvailable = true;
                    break;
                }
            

            if (!isRoomAvailable)
            {
                MessageWindow mw = new MessageWindow();
                mw.Title = "Room not available";
                mw.message.Content = "Room is not available!";
                mw.ShowDialog();
              
            }
            else ScheduleBasicRoomRenovation(timeInterval);
           
            if (!isRoomAvailable) FillAlternativeTimeIntervals(timeInterval, minutes);
           
        }

        private void FillAlternativeTimeIntervals(TimeInterval timeInterval, int intMinutes)
        {
            List<TimeInterval> alternativeTimeIntervals = new List<TimeInterval>();

            timeInterval.StartTime = timeInterval.EndTime;
            timeInterval.EndTime = timeInterval.StartTime.AddMinutes(intMinutes);
            TimeInterval time = new TimeInterval(timeInterval.StartTime, timeInterval.EndTime);

            if (roomService.IsRoomAvailableByTime(room, time)) 
                alternativeTimeIntervals.Add(time);
        
            searchAlternativeTerms.ItemsSource = alternativeTimeIntervals;
            searchAlternativeTerms.Columns[0].Visibility = Visibility.Hidden;
        }

        private void SearchAlternativeTerms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  
            TimeInterval selectedTimeInterval = (TimeInterval)searchAlternativeTerms.SelectedItem;
            ScheduleBasicRoomRenovation(selectedTimeInterval);
        }

        private void ScheduleBasicRoomRenovation(TimeInterval timeInterval)
        {
            Appointment appointmentRenovation = new Appointment(null, null, room, AppointmentType.renovation, timeInterval);
            appointmentSchedulingService.Create(appointmentRenovation);
            MessageWindow ms = new MessageWindow();
            ms.Title = "Scheduled renovation";
            ms.message.Content = descriptioOfRenovation.Text + " is scheduled in room " + room.RoomNumber;
            ms.ShowDialog();
        }

        private void ChooseStartTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)chooseStartTime.SelectedItem;

            DateTime d1 = startDatePicker.SelectedDate.Value;
            DateTime d2 = (DateTime)item.Tag;

            startTime = new DateTime(d1.Year, d1.Month, d1.Day, d2.Hour, d2.Minute, 0);
        }

        private void ChooseEndTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)chooseEndTime.SelectedItem;

            DateTime d1 = endDatePicker.SelectedDate.Value;
            DateTime d2 = (DateTime)item.Tag;

            endTime = new DateTime(d1.Year, d1.Month, d1.Day, d2.Hour, d2.Minute, 0);
        }
    }
}
