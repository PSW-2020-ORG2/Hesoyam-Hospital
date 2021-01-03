using Appointments.DTOs;
using Appointments.Service.Abstract;
using System;
using System.Collections.Generic;

namespace Appointments.Mappers
{
    public static class PriorityIntervalMapper
    {
        public static PriorityIntervalDTO ToDto(long doctorId, DateTime dateTime, IHttpRequestSender httpRequestSender)
        {
            return new PriorityIntervalDTO(dateTime, dateTime.AddMinutes(AppointmentMapper.AppointmentDurationMinutes), doctorId, httpRequestSender.GetDoctorFullName(doctorId));
        }

        public static List<PriorityIntervalDTO> ListToDtoListForOneDoctor(long doctorId, List<DateTime> dateTimes, IHttpRequestSender httpRequestSender)
        {
            List<PriorityIntervalDTO> dtos = new List<PriorityIntervalDTO>();
            foreach (DateTime dateTime in dateTimes)
            {
                dtos.Add(ToDto(doctorId, dateTime, httpRequestSender));
            }
            return dtos;
        }
    }
}
