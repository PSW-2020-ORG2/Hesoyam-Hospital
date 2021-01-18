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
using Backend.DTOs;
using Backend.Model.PatientModel;
using Backend.Service.MedicalService;

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for ShowSchedule.xaml
    /// </summary>
    public partial class ShowSchedule : Window
    {
        private readonly AppointmentService appointmentService = Backend.AppResources.getInstance().appointmentService;

        public ShowSchedule()
        {
            InitializeComponent();
        }

        private void buttonScheduledAppointments_Click(object sender, RoutedEventArgs e)
        {
            List<Appointment> appointments = new List<Appointment>();
            //MessageBox.Show(appointments.ToString());
            List<AppointmentDTO> appointmentDTO = new List<AppointmentDTO>();
            foreach (Appointment appointment in appointments) 
            {
                MessageBox.Show(appointment.ToString());
                if (appointment.AppointmentType == AppointmentType.checkup) 
                {
                        
                }
            }
            searchApp.ItemsSource = appointmentDTO;
            // List<PriorityIntervalDTO> priorityIntervalDTOs = (List<PriorityIntervalDTO>)appointmentSchedulingService.GetRecommendedTimes(priorityInterval);
            //searchApp.ItemsSource = priorityIntervalDTOs;
            
            
        }

        private void buttonScheduledRelocations_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonScheduledRenovations_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
