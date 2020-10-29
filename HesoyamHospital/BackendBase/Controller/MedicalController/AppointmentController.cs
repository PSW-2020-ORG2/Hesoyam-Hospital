// File:    AppointmentController.cs
// Author:  nikola
// Created: 22. maj 2020 16:44:01
// Purpose: Definition of Class AppointmentController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Service.MedicalService;
using SIMS.Util;

namespace SIMS.Controller.MedicalController
{
    public class AppointmentController : IController<Appointment, long>
    {

        private AppointmentService _appointmentService;
        private AppointmentRecommendationService _appointmentRecommendationService;

        public AppointmentController(AppointmentService appointmentService, AppointmentRecommendationService appointmentRecommendationService)
        {
            _appointmentService = appointmentService;
            _appointmentRecommendationService = appointmentRecommendationService;
        }

        public List<Appointment> GetRecommendedAppointments(AppointmentRecommendationDTO recommendation)
            => _appointmentRecommendationService.GetRecommendedAppointments(recommendation);

        public Appointment CancelAppointment(Appointment appointment)
            => _appointmentService.CancelAppointment(appointment);

        public IEnumerable<Appointment> GetPatientAppointments(Patient patient)
            => _appointmentService.GetPatientAppointments(patient);

        public IEnumerable<Appointment> GetAppointmentsByTime(TimeInterval timeInterval)
            => _appointmentService.GetAppointmentsByTime(timeInterval);

        public IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor)
            => _appointmentService.GetAppointmentsByDoctor(doctor);

        public IEnumerable<Appointment> GetCanceledAppointments()
            => _appointmentService.GetCanceledAppointments();

        public IEnumerable<Appointment> GetCompletedAppointmentsByPatient(Patient patient)
            => _appointmentService.GetCompletedAppointmentsByPatient(patient);

        public IEnumerable<Appointment> GetAppointmentsByRoom(Room room)
            => _appointmentService.GetAppointmentsByRoom(room);

        public IEnumerable<Appointment> GetFilteredAppointment(AppointmentFilter appointmentFilter)
            => _appointmentService.GetFilteredAppointment(appointmentFilter);

        public IEnumerable<Appointment> GetUpcomingAppointmentsForPatient(Patient patient)
            => _appointmentService.GetUpcomingAppointmentsForPatient(patient);

        public IEnumerable<Doctor> GetRecentDoctorsForPatient(Patient patient)
            => _appointmentService.GetRecentDoctorsForPatient(patient);

        public IEnumerable<Appointment> GetUpcomingAppointmentsForDoctor(Doctor doctor)
            => _appointmentService.GetUpcomingAppointmentsForDoctor(doctor);

        public bool IsAppointmentChangeable(Appointment appointment)
            => _appointmentService.IsAppointmentChangeable(appointment);

        public IEnumerable<Doctor> GetAvailableDoctorsByTime(TimeInterval timeInterval)
        {
            throw new NotImplementedException();
        }

        public void AutoDeleteCanceledAppointments()
            => _appointmentService.AutoDeleteCanceledAppointments();

        public IEnumerable<Appointment> GetAll()
            => _appointmentService.GetAll();

        public Appointment GetByID(long id)
            => _appointmentService.GetByID(id);

        public Appointment Create(Appointment entity)
            => _appointmentService.Create(entity);

        public void Update(Appointment entity)
            => _appointmentService.Update(entity);

        public void Delete(Appointment entity)
            => _appointmentService.Delete(entity);

    }
}