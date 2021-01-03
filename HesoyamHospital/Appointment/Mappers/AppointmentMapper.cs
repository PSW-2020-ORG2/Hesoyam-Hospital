using System;
using System.Collections.Generic;
using Appointments.DTOs;
using Appointments.Service.Abstract;
using Appointments.Model;
using Appointments.Util;

namespace Appointments.Mappers
{
    public static class AppointmentMapper
    {
        public const long AppointmentDurationMinutes = 30;

        public static Appointment AppointmentDtoToAppointment(AppointmentDTO dto, IHttpRequestSender httpRequestSender)
            => new Appointment
            {
                DoctorInAppointmentId = dto.DoctorId,
                Canceled = false,
                AbleToFillOutSurvey = true,
                AppointmentType = AppointmentType.checkup,
                PatientId = dto.PatientId,
                RoomId = httpRequestSender.GetRoomIdForDoctor(dto.DoctorId),
                TimeInterval = new TimeInterval
                {
                    StartTime = dto.DateAndTime,
                    EndTime = dto.DateAndTime.AddMinutes(AppointmentDurationMinutes)
                }
            };

        public static List<AppointmentForObservationDTO> AppointmentToAppointmentForObservationDto(List<Appointment> appointments, IHttpRequestSender httpRequestSender)
        {
            List<AppointmentForObservationDTO> result = new List<AppointmentForObservationDTO>();
            foreach (Appointment appointment in appointments)
                result.Add(AppointmentToAppointmentForObservationDto(appointment, httpRequestSender));
            return result;
        }

        public static AppointmentForObservationDTO AppointmentToAppointmentForObservationDto(Appointment appointment, IHttpRequestSender httpRequestSender)
            => new AppointmentForObservationDTO
            {
                AppointmentId = appointment.Id,
                AppointmentState = CalculateAppointmentState(appointment),
                TimeInterval = appointment.TimeInterval,
                Department = httpRequestSender.GetDoctorSpecialization(appointment.DoctorInAppointmentId),
                DoctorName = httpRequestSender.GetDoctorFullName(appointment.DoctorInAppointmentId),
                RoomNumber = httpRequestSender.GetRoomNumberById(appointment.DoctorInAppointmentId),
                AbleToFillOutSurvey = appointment.AbleToFillOutSurvey
            };

        private static string CalculateAppointmentState(Appointment appointment)
        {
            if (appointment.Canceled) return AppointmentState.CANCELLED.ToString();
            if (appointment.TimeInterval.IsDateTimeBetween(DateTime.Now)) return AppointmentState.IN_PROGRESS.ToString();
            if (appointment.TimeInterval.IsInThePast()) return AppointmentState.FINISHED.ToString();
            return AppointmentState.INCOMING.ToString();
        }
    }
}
