using Backend.Model.PatientModel;
using System;
using System.Collections.Generic;
using WebApplication.Appointments.DTOs;

namespace WebApplication.Appointments
{
    public static class AppointmentMapper
    {
        public static List<AppointmentForObservationDTO> AppointmentToAppointmentForObservationDto(List<Appointment> appointments)
        {
            List<AppointmentForObservationDTO> result = new List<AppointmentForObservationDTO>();
            foreach (Appointment appointment in appointments)
                result.Add(AppointmentToAppointmentForObservationDto(appointment));
            return result;
        }

        public static AppointmentForObservationDTO AppointmentToAppointmentForObservationDto(Appointment appointment)
        {
            return new AppointmentForObservationDTO(appointment.Id, CalculateAppointmentState(appointment), appointment.TimeInterval, appointment.DoctorInAppointment.Specialisation.ToString(), appointment.DoctorInAppointment.FullName, appointment.DoctorInAppointment.Office.RoomNumber, appointment.AbleToFillOutSurvey);
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
