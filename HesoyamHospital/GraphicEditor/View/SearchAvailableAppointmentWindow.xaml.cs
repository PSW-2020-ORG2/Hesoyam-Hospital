using System;
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
using System.Data;
using GraphicEditor.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using Backend.Model.PatientModel;
using GraphicEditor.View;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for SearchAvailableAppointmentWindow.xaml
    /// </summary>
    public partial class SearchAvailableAppointmentWindow : Window
    {
       
        private readonly DoctorService doctorService;
        private readonly PatientService patientService;
        private readonly AppointmentSchedulingService appointmentSchedulingService;
        private readonly RoomService roomService;
        private SearchService searchService;
        private List<Room> availableRooms;
        private Room availableRoom;
        private Doctor doctorInAppointment;
        private TimeInterval timeInterval;
        private List<PatientDTO> patientDTOs;
        private PatientDTO patientInAppointmentDTO;
        private List<PriorityIntervalDTO> priorityIntervalDTOs;
        private PriorityIntervalDTO selectedTerm;
        
        public SearchAvailableAppointmentWindow()
        {
            InitializeComponent();
            doctorService = Backend.AppResources.getInstance().doctorService;
            patientService = Backend.AppResources.getInstance().patientService;
            appointmentSchedulingService = Backend.AppResources.getInstance().appointmentSchedulingService;
            roomService = Backend.AppResources.getInstance().roomService;
            List<Doctor> doctors = (List<Doctor>) doctorService.GetAll();
            searchService = new SearchService();

            foreach (Doctor doctor in doctors)
            {
                ComboBoxItem item = new ComboBoxItem();   
                item.Tag = doctor;
                item.Content = doctor.FullName;
                searchDoctor.Items.Add(item);
            }
        }

        private void SearchAvailableAppointmentClick(object sender, RoutedEventArgs e)
        {
            ShowWPFElement1();
            string doctorName = searchDoctor.SelectedItem.ToString();
            DateTime startTime = fromDatePicker.SelectedDate.Value;
            DateTime endTime = toDatePicker.SelectedDate.Value;
            bool priority = priorityDoctor.IsChecked.Value;
            ComboBoxItem item = (ComboBoxItem)searchDoctor.SelectedItem;
            doctorInAppointment = (Doctor)item.Tag;

            priorityIntervalDTOs = new List<PriorityIntervalDTO>();
            PriorityIntervalDTO priorityInterval = new PriorityIntervalDTO(startTime, endTime, doctorName, doctorInAppointment.Id, priority);
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
                ShowTwoButtons();
                DateTime startTime = selectedTerm.StartTime;
                DateTime endTime = selectedTerm.EndTime;
                timeInterval = new TimeInterval(startTime, endTime);
                availableRooms = (List<Room>)roomService.GetAvailableRoomsByDate(timeInterval);
            }
        }


        private void SearchPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patientInAppointmentDTO = (PatientDTO)searchPatients.SelectedItem;
            
            if (patientInAppointmentDTO != null)
            {
                HideSearchForPatient();
                buttonScheduleAppointment.Visibility = Visibility.Visible;
            }
        }

        private void ButtonSeeAvailableRoom_Click(object sender, RoutedEventArgs e)
        {
            MapLocation mapLocation = searchService.GetLocationByRoomName(availableRooms[0].RoomNumber);
            searchService.DisplayResults(mapLocation);
        }

        private void ButtonShowPatients_Click(object sender, RoutedEventArgs e)
        {
            ShowWPFElement2();
            List<Patient> patients = (List<Patient>)patientService.GetAll();
            patientDTOs = PatientMapper.ConvertFromPatientToDTO(patients);
            searchPatients.ItemsSource = patientDTOs;
            searchPatients.Columns[0].Visibility = Visibility.Hidden;
            
        }

        public void FilterPatientByName_TextChanged(object sender, EventArgs e)
        {
            searchPatients.ItemsSource = patientDTOs.FindAll(x => x.Name.ToLowerInvariant().Contains(textBoxForInputPatient.Text.ToLower()));
        }

        private void ButtonScheduleAppointment_Click(object sender, RoutedEventArgs e)
        {
            Patient patientInAppointment = patientService.GetByID(patientInAppointmentDTO.Id);
            availableRoom = availableRooms[0];
            Appointment appointmentForPatient = new Appointment(doctorInAppointment, patientInAppointment, availableRoom, AppointmentType.checkup, timeInterval);
            appointmentSchedulingService.Create(appointmentForPatient);
            ShowMessage();
            RefreshDataGrid();
        }


        private static void ShowMessage()
        {
            MessageWindow mw = new MessageWindow();
            mw.Title = "Scheduled examination";
            mw.message.Content = "Successfully scheduled examination!";
            mw.ShowDialog();
        }

        private void RefreshDataGrid()
        {
            searchPatients.Visibility = Visibility.Hidden;
            searchAvailable.Visibility = Visibility.Visible;
            HideButtons();
        }

        private void ShowWPFElement1()
        {
            HideButtons();
            HideSearchForPatient();
            searchPatients.Visibility = Visibility.Hidden;
            searchAvailable.Visibility = Visibility.Visible;
        }

        private void HideSearchForPatient()
        {
            labelSearchPatient.Visibility = Visibility.Hidden;
            textBoxForInputPatient.Visibility = Visibility.Hidden;
        }

        private void ShowWPFElement2()
        {
            HideButtons();
            searchAvailable.Visibility = Visibility.Hidden;
            searchPatients.Visibility = Visibility.Visible;
            labelSearchPatient.Visibility = Visibility.Visible;
            textBoxForInputPatient.Visibility = Visibility.Visible;
            
        }

        private void ShowTwoButtons()
        {
            buttonSeeAvailableRoom.Visibility = Visibility.Visible;
            buttonShowPatients.Visibility = Visibility.Visible;
        }

        private void HideButtons()
        {
            buttonSeeAvailableRoom.Visibility = Visibility.Hidden;
            buttonShowPatients.Visibility = Visibility.Hidden;
            buttonScheduleAppointment.Visibility = Visibility.Hidden;
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
    }
}
