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
        private TimeInterval timeInterval;
        private List<PatientDTO> patientDTOs;
        private PatientDTO patientInAppointmentDTO;
        private long idDoctor;
        
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
            ShowWPFElement(false);
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            DateTime startTime = fromDatePicker.SelectedDate.Value;
            DateTime endTime = toDatePicker.SelectedDate.Value;
            bool priority = priorityDoctor.IsChecked.Value;
            ComboBoxItem item = (ComboBoxItem)searchDoctor.SelectedItem;
            Doctor doctor = (Doctor)item.Tag;
            idDoctor = doctor.Id;

            PriorityIntervalDTO priorityInterval = new PriorityIntervalDTO(startTime, endTime, doctor.FullName, doctor.Id, priority);
            List<PriorityIntervalDTO> priorityIntervalDTOs = (List<PriorityIntervalDTO>)appointmentSchedulingService.GetRecommendedTimes(priorityInterval);

            searchAvailable.ItemsSource = priorityIntervalDTOs;
            searchAvailable.Columns[4].Visibility = Visibility.Hidden;
            searchAvailable.Columns[3].Visibility = Visibility.Hidden;
            searchPatients.Visibility = Visibility.Hidden;
            searchAvailable.Visibility = Visibility.Visible;
            HideButtons();
        }

        private void SearchAvailable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PriorityIntervalDTO selectedTerm = (PriorityIntervalDTO)searchAvailable.SelectedItem;
            if (selectedTerm != null)
            {
                ShowButtons();
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
            ShowWPFElement(true);
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
            Doctor doctorInAppointment = doctorService.GetByID(idDoctor);
            Room availableRoom = availableRooms[0];
            Appointment appointmentForPatient = new Appointment(doctorInAppointment, patientInAppointment, availableRoom, AppointmentType.checkup, timeInterval);
            appointmentSchedulingService.SaveAppointment(appointmentForPatient);
            ShowMessage();
            LoadDataGrid();
        }

        private void ShowWPFElement(bool isActivePatientDataGrid)
        {
            HideButtons();
            if (isActivePatientDataGrid)
            {
                VisibleSearchForPatient();
                searchAvailable.Visibility = Visibility.Hidden;
                searchPatients.Visibility = Visibility.Visible;
            }
            else
            {
                HideSearchForPatient();
                searchPatients.Visibility = Visibility.Hidden;
                searchAvailable.Visibility = Visibility.Visible;
            }
            
        }

        private void VisibleSearchForPatient()
        {
            labelSearchPatient.Visibility = Visibility.Visible;
            textBoxForInputPatient.Visibility = Visibility.Visible;
        }

        private static void ShowMessage()
        {
            MessageWindow mw = new MessageWindow();
            mw.Title = "Scheduled examination";
            mw.message.Content = "Successfully scheduled examination!";
            mw.ShowDialog();
        }

        private void HideSearchForPatient()
        {
            labelSearchPatient.Visibility = Visibility.Hidden;
            textBoxForInputPatient.Visibility = Visibility.Hidden;
        }

        private void ShowButtons()
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
