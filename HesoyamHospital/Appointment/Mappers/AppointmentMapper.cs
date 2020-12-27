using System;
using System.Collections.Generic;
using Appointments.DTOs;
using Appointments.Service.Abstract;
using Appointments.Repository;
using Appointments.Service;
using Appointments.Repository.SQLRepository.Base;
using Appointments.Model.ScheduleModel;
using Appointments.Model.UserModel;
using Appointments.Model.Util;

namespace Appointments.Mappers
{
    public static class AppointmentMapper
    {
        public const long AppointmentDurationMinutes = 30;
        private static readonly IPatientService _patientService = new PatientService(new PatientRepository(new SQLStream<Patient>()));
        private static readonly IDoctorService _doctorService = new DoctorService(new DoctorRepository(new SQLStream<Doctor>()));

        public static Appointment AppointmentDtoToAppointment(AppointmentDTO dto)
        {
            Appointment appointment = new Appointment();
            Doctor doctorInAppointment = _doctorService.GetByID(dto.DoctorId);
            appointment.DoctorInAppointment = doctorInAppointment;
            appointment.Canceled = false;
            appointment.AbleToFillOutSurvey = true;
            appointment.AppointmentType = AppointmentType.checkup;
            appointment.Patient = _patientService.GetByID(dto.PatientId);
            appointment.Room = GetRoom(doctorInAppointment);
            appointment.TimeInterval = new TimeInterval
            {
                StartTime = dto.DateAndTime,
                EndTime = dto.DateAndTime.AddMinutes(AppointmentDurationMinutes)
            };
            return appointment;
        }

        private static Room GetRoom(Doctor doctor)
        {
            if (doctor == null || doctor.Office == null) return null;
            return doctor.Office;
        }

        public static List<AppointmentForObservationDTO> AppointmentToAppointmentForObservationDto(List<Appointment> appointments)
        {
            List<AppointmentForObservationDTO> result = new List<AppointmentForObservationDTO>();
            foreach (Appointment appointment in appointments)
                result.Add(AppointmentToAppointmentForObservationDto(appointment));
            return result;
        }

        public static AppointmentForObservationDTO AppointmentToAppointmentForObservationDto(Appointment appointment)
        {
            return new AppointmentForObservationDTO(appointment.Id, CalculateAppointmentState(appointment), appointment.TimeInterval, appointment.DoctorInAppointment.Specialisation.ToString(), appointment.DoctorInAppointment.FullName, appointment.DoctorInAppointment.Office == null ? "" : appointment.DoctorInAppointment.Office.RoomNumber, appointment.AbleToFillOutSurvey);
        }

        private static string CalculateAppointmentState(Appointment appointment)
        {
            if (appointment.Canceled) return AppointmentState.CANCELLED.ToString();
            if (appointment.TimeInterval.IsDateTimeBetween(DateTime.Now)) return AppointmentState.IN_PROGRESS.ToString();
            if (appointment.TimeInterval.IsInThePast()) return AppointmentState.FINISHED.ToString();
            return AppointmentState.INCOMING.ToString();
        }
    }
}
