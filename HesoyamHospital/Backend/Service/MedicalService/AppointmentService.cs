// File:    AppointmentService.cs
// Author:  Geri
// Created: 19. maj 2020 20:26:06
// Purpose: Definition of Class AppointmentService

using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Exceptions;
using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository.MedicalRepository;
using Backend.Util;

namespace Backend.Service.MedicalService
{
    public class AppointmentService : IService<Appointment, long>
    {
        private IAppointmentStrategy _appointmentStrategy;
        private AppointmentRepository _appointmentRepository;
        private AppointmentNotificationSender _notificationSender;
        public IAppointmentStrategy AppointmentStrategy { get => _appointmentStrategy; set => _appointmentStrategy = value; }

        public AppointmentService(AppointmentRepository appointmentRepository,IAppointmentStrategy appointmentStrategy, AppointmentNotificationSender appointmentNotificationSender)
        {
            _appointmentRepository = appointmentRepository;
            _appointmentStrategy = appointmentStrategy;
            _notificationSender = appointmentNotificationSender;
        }

        protected void CheckSchedules(Appointment appointment)
        {
            if (!CheckDoctorSchedule(appointment))
                throw new AppointmentServiceException("Appointment clashes with doctor appointments!");

            if (!CheckPatientSchedule(appointment))
                throw new AppointmentServiceException("Appointment clashes with patient appointments!");

            if (!CheckRoomSchedules(appointment))
                throw new AppointmentServiceException("Appointment clashes with room appointments!");
        }

        protected bool CheckDoctorSchedule(Appointment appointment)
            => _appointmentRepository.GetAppointmentsByDoctor(appointment.DoctorInAppointment)
                .Where(app => app.TimeInterval.IsOverlappingWith(appointment.TimeInterval)).Count() <= 0;

        protected bool CheckPatientSchedule(Appointment appointment)
            => _appointmentRepository.GetPatientAppointments(appointment.Patient)
                .Where(app => app.TimeInterval.IsOverlappingWith(appointment.TimeInterval)).Count() <= 0;

        protected bool CheckRoomSchedules(Appointment appointment)
            => _appointmentRepository.GetAppointmentsByRoom(appointment.Room)
                .Where(app => app.TimeInterval.IsOverlappingWith(appointment.TimeInterval)).Count() <= 0;


        protected void CheckType(Appointment appointment)
            => _appointmentStrategy.CheckType(appointment);

        public List<Appointment> GetAppointmentsForDoctorInNex30Minutes(DoctorType type)
        {
            List<Appointment> allAppointments = (List<Appointment>)GetAll();
            List<Appointment> result = new List<Appointment>();
            foreach (Appointment a in allAppointments) 
            {
                if (a.DoctorInAppointment.Specialisation == type && DateTime.Now <= a.TimeInterval.StartTime && !a.Canceled &&
                    a.TimeInterval.StartTime <= DateTime.Now.AddMinutes(30))
                {
                    result.Add(a);
                }
            }
            return result;
        }

        public Appointment CancelAppointment(Appointment appointment)
        {
            // TODO: Proveri da li moze da se otkaze appointment
            _appointmentStrategy.Validate(appointment);
            appointment.Canceled = true;
            _appointmentRepository.Update(appointment);
            return appointment;
        }

        public IEnumerable<Appointment> GetPatientAppointments(Patient patient)
            => _appointmentRepository.GetPatientAppointments(patient);

        public IEnumerable<Appointment> GetAppointmentsByTime(TimeInterval timeInterval)
            => _appointmentRepository.GetAppointmentsByTime(timeInterval);

        public IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor)
            => _appointmentRepository.GetAppointmentsByDoctor(doctor);

        public IEnumerable<Appointment> GetCanceledAppointments()
            => _appointmentRepository.GetCanceledAppointments();

        public IEnumerable<Appointment> GetCompletedAppointmentsByPatient(Patient patient)
            => GetPatientAppointments(patient).Where(appointment => IsCompleted(appointment));

        public IEnumerable<Appointment> GetAppointmentsByRoom(Room room)
        {
            List<Appointment> appointments = (List<Appointment>)GetAll();
            List<Appointment> result = new List<Appointment>();
            foreach (Appointment a in appointments)
            {
                if (a.Room.Id == room.Id)
                {
                    result.Add(a);
                }
                
            }
            return result;
        }
           

        public IEnumerable<Appointment> GetFilteredAppointment(AppointmentFilter appointmentFilter)
            => _appointmentRepository.GetFilteredAppointment(appointmentFilter);

        public IEnumerable<Appointment> GetUpcomingAppointmentsForPatient(Patient patient)
            => _appointmentRepository.GetPatientAppointments(patient).Where(appointment => IsInFuture(appointment));

        public IEnumerable<Doctor> GetRecentDoctorsForPatient(Patient patient)
            => GetPatientAppointments(patient).Select(app => app.DoctorInAppointment);

        public IEnumerable<Appointment> GetUpcomingAppointmentsForDoctor(Doctor doctor)
            => GetAppointmentsByDoctor(doctor).Where(appointment => IsInFuture(appointment));

        public bool IsAppointmentChangeable(Appointment appointment)
            => _appointmentStrategy.isAppointmentChangeable(appointment);

        public IEnumerable<Appointment> GetAll()
            => _appointmentRepository.GetAllEager();

        public Appointment GetByID(long id)
            => _appointmentRepository.GetEager(id);

        public Appointment Create(Appointment entity)
        {
            Validate(entity);
            Appointment createdAppointment = _appointmentRepository.Create(entity);
            _notificationSender.SendCreateNotification(createdAppointment);
            return createdAppointment;
        }

        public void Delete(Appointment entity)
            => _appointmentRepository.Delete(entity);

        public void Update(Appointment entity)
        {
            Validate(entity);
            if (IsAppointmentChangeable(entity)) {
                Appointment oldAppointment = GetByID(entity.Id);
                _appointmentRepository.Update(entity);
                _notificationSender.SendUpdateNotification(oldAppointment, entity);
            }
        }

        public void Validate(Appointment entity)
        {
            _appointmentStrategy.Validate(entity);
            CheckSchedules(entity);
        }

        private bool IsCompleted(Appointment appointment)
            => appointment.IsCompleted() && !appointment.Canceled;

        private bool IsInFuture(Appointment appointment)
            => appointment.IsInFuture() && !appointment.Canceled;

    }
}