using Backend.DTOs;
using Backend.Model.DoctorModel;
using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service.HospitalManagementService;
using Backend.Service.MedicalService;
using Backend.Service.UsersService;
using Backend.Util;
using Castle.Core.Internal;
using GraphicEditor.DTOs;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for EmergencyExamination.xaml
    /// </summary>
    public partial class EmergencyExamination : Window
    {
        private readonly PatientService patientService = Backend.AppResources.getInstance().patientService;
        private readonly AppointmentSchedulingService appointmentSchedulingService = Backend.AppResources.getInstance().appointmentSchedulingService;
        private readonly DoctorService doctorService = Backend.AppResources.getInstance().doctorService;
        private readonly RoomService roomService = Backend.AppResources.getInstance().roomService;
        private readonly InventoryService inventoryService = Backend.AppResources.getInstance().inventoryService;
        private readonly AppointmentService appointmentService = Backend.AppResources.getInstance().appointmentService;

        public EmergencyExamination()
        {
            InitializeComponent();
            List<DoctorType> specialisations = new List<DoctorType>();
            specialisations.Add(DoctorType.GENERAL_PRACTITIONER);
            specialisations.Add(DoctorType.SURGEON);
            specialisations.Add(DoctorType.CARDIOLOGIST);
            specialisations.Add(DoctorType.ENDOCRINIOLOGIST);
            specialisations.Add(DoctorType.DERMATOLOGIST);
            specialisations.Add(DoctorType.GASTROENEROLOGIST);
            specialisations.Add(DoctorType.INFECTOLOGIST);
            specialisations.Add(DoctorType.OPHTAMOLOGIST);
            foreach (DoctorType type in specialisations) {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = type.ToString();
                item.Tag = type;
                chooseExaminationType.Items.Add(item);
            }
        }

        private void ButtonScheduleEmergencyAppointment_Click(object sender, RoutedEventArgs e)
        {
            List<Patient> patients = (List<Patient>)patientService.GetAll();

            string name = Name.Text;
            string surname = Surname.Text;
            string jmbg = JMBG.Text;
            Patient patient = null;
            ComboBoxItem item = (ComboBoxItem)chooseExaminationType.SelectedItem;
            DoctorType type = (DoctorType)item.Tag;   

            PriorityIntervalDTO dto = new PriorityIntervalDTO(DateTime.Today, DateTime.Today,null,false);
            PriorityIntervalDTO interval = appointmentSchedulingService.GetAvailableTermsForEmergencyExamination(dto, type);

            foreach (Patient p in patients)
            {
                if (jmbg == p.Jmbg && surname == p.Surname && name == p.Name)
                {
                    patient = p;
                    break;
                }
            }
            if (patient == null)
            {
                StringBuilder bld = new StringBuilder();
                string username = (name + surname).ToLower();
                bld.Append(username);
                
                while (!patientService.IsUsernameUnique(username))
                    bld.Append(jmbg.Substring(0, 4));
               

                Patient p = new Patient(bld.ToString(), jmbg, DateTime.Today, name, surname, null, jmbg, Sex.OTHER, DateTime.Today, null, null, null, null, null, null, null, null);
                patientService.Create(p);
                patient = p;
         
            }
            if (interval != null)
            {
                DateTime startTime = interval.StartTime;
                DateTime endTime = interval.EndTime;
                TimeInterval timeInterval = new TimeInterval(startTime, endTime);
                List<Room> availableRooms = (List<Room>)roomService.GetAllExaminationRooms(timeInterval);
                Room roomForAppointment;
                if (Global.inventories.IsNullOrEmpty())
                    roomForAppointment = availableRooms[0];
                else
                    roomForAppointment = inventoryService.FindAvailableRoomWithEquipment(availableRooms, Global.inventories);

                Doctor doctorInAppointment = doctorService.GetByID(interval.DoctorId);
                if (roomForAppointment != null)
                {
                    Appointment appointmentForPatient = new Appointment(doctorInAppointment, patient, roomForAppointment, AppointmentType.checkup, timeInterval);
                    appointmentSchedulingService.SaveAppointment(appointmentForPatient);
                    MessageBox.Show("Successfully scheduled examination!");
                }
                else
                {
                    MessageBox.Show("There are no rooms available for this appointment");
                }
            }
            else 
            {
                MessageBox.Show("No available terms in the next 30minutes. Some appointments have to be rescheduled!");
                //Vrati sve zakazane u narednih pola sata, nadje 3 najbolja
                Dictionary<Appointment, double> appointmentsForRescheduling = getAppointmentsForRescheduing(type);
                List<RescheduleAppointmentDTO> rescheduleAppointmentDTOs = new List<RescheduleAppointmentDTO>();
                AppointmentAnalysisDataGrid dataGrid = new AppointmentAnalysisDataGrid();
                rescheduleAppointmentDTOs = RescheduleAppointmentMapper.AppointmentToRescheduleAppointmentDto(appointmentsForRescheduling);
                dataGrid.searchAvailable.ItemsSource = rescheduleAppointmentDTOs;
                dataGrid.Show();

            }
        }

        private Dictionary<Appointment, double> getAppointmentsForRescheduing(DoctorType type)
        {
            List<Appointment> appointments = appointmentService.GetAppointmentsForDoctorInNex30Minutes(type);
            List<double> score = new List<double>();
            List<double> sortedScore = new List<double>();
            Dictionary<Appointment, double> result = new Dictionary<Appointment, double>();
            foreach (Appointment a in appointments)
            {
                score.Add(analyseAppointment(a));
                sortedScore.Add(analyseAppointment(a));
            }
            sortedScore.Sort();
            for (int i = 0; i < 3; i++)
            {
                if (appointments.Count == i)
                    break;
                int index = score.IndexOf(sortedScore[i]);
                result[appointments[index]] = score[index];
            }
            return result;
            


        }

        private double analyseAppointment(Appointment appointment)
        {
            PriorityIntervalDTO dto = new PriorityIntervalDTO(DateTime.Now, DateTime.Now.AddDays(5), appointment.DoctorInAppointment.Name, appointment.DoctorInAppointment.Id, true);
            List<PriorityIntervalDTO> appointments = (List<PriorityIntervalDTO>)appointmentSchedulingService.GetRecommendedTimes(dto);
            if (!appointments.IsNullOrEmpty())
                return (appointments[0].StartTime - appointment.TimeInterval.StartTime).TotalMinutes;
            else
                return 12000;
        }

        private void ChooseExaminationType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)chooseExaminationType.SelectedItem;
            DoctorType specialization = (DoctorType)item.Tag;
            Global.inventories = new List<string>();
            if (specialization != DoctorType.GENERAL_PRACTITIONER)
            {
                EquipmentForSpecialistAppointment equipmentForSpecialistAppointment = new EquipmentForSpecialistAppointment();
                equipmentForSpecialistAppointment.Show();
            }
        }
    }
}
