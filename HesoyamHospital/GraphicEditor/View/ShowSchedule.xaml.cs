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
using Backend.Model.UserModel;
using Backend.Service.MedicalService;

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for ShowSchedule.xaml
    /// </summary>
    public partial class ShowSchedule : Window
    {
        private readonly AppointmentService appointmentService = Backend.AppResources.getInstance().appointmentService;
        private Room room;

        public ShowSchedule(Room room1)
        {
            InitializeComponent();
            room = room1;
        }


        private void buttonScheduledAppointments_Click(object sender, RoutedEventArgs e)
        {
            List<Appointment> appointments = new List<Appointment>();
            List<AppointmentDTO> appointmentsDto = new List<AppointmentDTO>();

            appointments = (List<Appointment>)appointmentService.GetAppointmentsByRoom(room);
            List<Appointment> appointmentNew = new List<Appointment>();
            
            foreach (Appointment appointment in appointments) 
            {
                if (appointment.AppointmentType == AppointmentType.checkup || appointment.AppointmentType == AppointmentType.operation) 
                {
                    appointmentNew.Add(appointment);
                }
            }

            appointmentsDto = AppointmentMapper.AppointmentToAppointmentDto(appointmentNew);
            searchApp.ItemsSource = appointmentsDto;
           
            
        }

        private void buttonScheduledRelocations_Click(object sender, RoutedEventArgs e)
        {
            List<Appointment> appointments = new List<Appointment>();
            List<AppointmentDTO> appointmentsDto = new List<AppointmentDTO>();

            appointments = (List<Appointment>)appointmentService.GetAppointmentsByRoom(room);
            List<Appointment> appointmentNew = new List<Appointment>();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.AppointmentType == AppointmentType.relocation)
                {
                    appointmentNew.Add(appointment);
                }
            }

            appointmentsDto = AppointmentMapper.AppointmentToAppointmentDto(appointmentNew);
            searchApp.ItemsSource = appointmentsDto;

        }

        private void buttonScheduledRenovations_Click(object sender, RoutedEventArgs e)
        {
            List<Appointment> appointments = new List<Appointment>();
            List<AppointmentDTO> appointmentsDto = new List<AppointmentDTO>();

            appointments = (List<Appointment>)appointmentService.GetAppointmentsByRoom(room);
            List<Appointment> appointmentNew = new List<Appointment>();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.AppointmentType == AppointmentType.renovation)
                {
                    appointmentNew.Add(appointment);
                }
            }

            appointmentsDto = AppointmentMapper.AppointmentToAppointmentDto(appointmentNew);
            searchApp.ItemsSource = appointmentsDto;

        }
    }
}
