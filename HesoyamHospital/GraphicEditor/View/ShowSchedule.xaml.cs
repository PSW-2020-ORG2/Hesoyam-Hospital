﻿using System;
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
using GraphicEditor.DTOs;

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for ShowSchedule.xaml
    /// </summary>
    public partial class ShowSchedule : Window
    {
        private readonly AppointmentService appointmentService = Backend.AppResources.getInstance().appointmentService;
        private Room room;
        private long type;

        public ShowSchedule(Room room1)
        {
            InitializeComponent();
            room = room1;
        }


        private void ButtonScheduledAppointments_Click(object sender, RoutedEventArgs e)
        {

            LoadAppointmentsInRoom();
            
        }
        private void LoadAppointmentsInRoom() 
        {
            List<Appointment> appointments = new List<Appointment>();
            List<ScheduledAppointmentDTO> appointmentsDto = new List<ScheduledAppointmentDTO>();
            type = 0;

            appointments = (List<Appointment>)appointmentService.GetAppointmentsByRoom(room);
            List<Appointment> appointmentNew = new List<Appointment>();

            foreach (Appointment appointment in appointments)
            {
                if ((appointment.AppointmentType == AppointmentType.checkup || appointment.AppointmentType == AppointmentType.operation) && appointment.IsInFuture() && !appointment.Canceled)
                {
                    appointmentNew.Add(appointment);
                }
            }

            appointmentsDto = ScheduledAppointmentMapper.ScheduledAppointmentToAppointmentDto(appointmentNew);
            searchApp.ItemsSource = appointmentsDto;

        }

        private void ButtonScheduledRelocations_Click(object sender, RoutedEventArgs e)
        {
            LoadRelocationsInRoom();
        }
        private void LoadRelocationsInRoom()
        {
            List<Appointment> appointments = new List<Appointment>();
            List<ScheduledAppointmentDTO> appointmentsDto = new List<ScheduledAppointmentDTO>();
            type = 1;

            appointments = (List<Appointment>)appointmentService.GetAppointmentsByRoom(room);
            List<Appointment> appointmentNew = new List<Appointment>();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.AppointmentType == AppointmentType.relocation && appointment.IsInFuture() && !appointment.Canceled)
                {
                    appointmentNew.Add(appointment);
                }
            }

            appointmentsDto = ScheduledAppointmentMapper.ScheduledAppointmentToAppointmentDto(appointmentNew);
            searchApp.ItemsSource = appointmentsDto;
        }

        private void ButtonScheduledRenovations_Click(object sender, RoutedEventArgs e)
        {
            LoadRenovationsInRoom();
        }

        private void LoadRenovationsInRoom()
        {
            List<Appointment> appointments = new List<Appointment>();
            List<ScheduledAppointmentDTO> appointmentsDto = new List<ScheduledAppointmentDTO>();
            type = 2;

            appointments = (List<Appointment>)appointmentService.GetAppointmentsByRoom(room);
            List<Appointment> appointmentNew = new List<Appointment>();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.AppointmentType == AppointmentType.renovation && appointment.IsInFuture() && !appointment.Canceled)
                {
                    appointmentNew.Add(appointment);
                }
            }

            appointmentsDto = ScheduledAppointmentMapper.ScheduledAppointmentToAppointmentDto(appointmentNew);
            searchApp.ItemsSource = appointmentsDto;
        }

        private void CancelAppointmnet(object sender, SelectionChangedEventArgs e)
        {
            ScheduledAppointmentDTO selected = (ScheduledAppointmentDTO)searchApp.SelectedItem;
            if (selected != null)
            {
                Appointment appointmentForCancelation = appointmentService.GetByID(selected.Id);
                try
                {
                    appointmentService.CancelAppointment(appointmentForCancelation);
                    MessageBox.Show("Appointment canceled!");
                    RefreshTable();
                }
                catch
                {
                    MessageBox.Show("Appointment too soon to be canceled!");
                }
                
            }
        }
        private void RefreshTable()
        {
            switch (type) {
                case 0:
                    LoadAppointmentsInRoom();
                    break;
                case 1:
                    LoadRelocationsInRoom();
                    break;
                case 2:
                    LoadRenovationsInRoom();
                    break;
            }
        }
    }
}
