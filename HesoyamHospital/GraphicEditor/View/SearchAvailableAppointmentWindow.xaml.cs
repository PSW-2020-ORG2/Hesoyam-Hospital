﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Backend.Model.UserModel;
using Backend.DTOs;
using Backend.Service.MedicalService;
using Backend.Service.UsersService;
using Backend.Service.HospitalManagementService;
using Backend.Util;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for SearchAvailableAppointmentWindow.xaml
    /// </summary>
    public partial class SearchAvailableAppointmentWindow : Window
    {
        private List<Doctor> doctors;
        private List<Room> availableRooms;
        private readonly DoctorService doctorService;
        private List<PriorityIntervalDTO> priorityIntervalDTOs;
        private readonly AppointmentSchedulingService appointmentSchedulingService;
        private readonly RoomService roomService;
        private SearchService searchService;
        private PriorityIntervalDTO selectedTerm;
        public SearchAvailableAppointmentWindow()
        {
            InitializeComponent();
            this.doctorService = Backend.AppResources.getInstance().doctorService;
            this.appointmentSchedulingService = Backend.AppResources.getInstance().appointmentSchedulingService;
            this.roomService = Backend.AppResources.getInstance().roomService;
            doctors = (List<Doctor>) doctorService.GetAll();
            searchService = new SearchService();

            foreach (Doctor doctor in doctors)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Tag = doctor;
                item.Content = doctor.FullName;
                searchDoctor.Items.Add(item);
            }
        }

        private void FromtDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                fromDatePicker.IsDropDownOpen = true;
                fromDatePicker.DisplayDateStart = DateTime.Today;
            }
        }

        private void ToDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                toDatePicker.IsDropDownOpen = true;
            }
        }

        private void SearchAvailableAppointmentClick(object sender, RoutedEventArgs e)
        {
            String doctorName = searchDoctor.SelectedItem.ToString();
            DateTime startTime = fromDatePicker.SelectedDate.Value;
            DateTime endTime = toDatePicker.SelectedDate.Value;
            bool priority = priorityDoctor.IsChecked.Value;
            ComboBoxItem item = (ComboBoxItem)searchDoctor.SelectedItem;
            Doctor doctor = (Doctor)item.Tag;

            priorityIntervalDTOs = new List<PriorityIntervalDTO>();

            PriorityIntervalDTO priorityInterval = new PriorityIntervalDTO(startTime, endTime, doctorName, doctor.Id, priority);

            priorityIntervalDTOs = (List<PriorityIntervalDTO>)appointmentSchedulingService.GetRecommendedTimes(priorityInterval);
            
            searchAvailable.ItemsSource = priorityIntervalDTOs;
            
            searchAvailable.Columns[4].Visibility = Visibility.Hidden;
            searchAvailable.Columns[3].Visibility = Visibility.Hidden;
        }

        private void SearchAvailable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTerm = (PriorityIntervalDTO)searchAvailable.SelectedItem;
            
            if (selectedTerm != null)
            {
                buttonSeeAvailableRoom.Visibility = Visibility.Visible;
                buttonScheduleAppointment.Visibility = Visibility.Visible;
            }

        }


        private void ButtonSeeAvailableRoom_Click(object sender, RoutedEventArgs e)
        {
            selectedTerm = (PriorityIntervalDTO)searchAvailable.SelectedItem;

            DateTime startTime = selectedTerm.StartTime;
            DateTime endTime = selectedTerm.EndTime;
            TimeInterval timeInterval = new TimeInterval(startTime, endTime);
            availableRooms = (List<Room>)roomService.GetAllExaminationRooms(timeInterval);

            Room availableRoom = availableRooms[0];
            MapLocation mapLocation = searchService.GetLocationByRoomName(availableRoom.RoomNumber);
            searchService.DisplayResults(mapLocation);
        }
    }
}
