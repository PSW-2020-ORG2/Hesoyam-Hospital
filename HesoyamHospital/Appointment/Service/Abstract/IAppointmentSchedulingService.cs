using Appointments.DTOs;
using Appointments.Model;
using System;
using System.Collections.Generic;

namespace Appointments.Service.Abstract
{
    public interface IAppointmentSchedulingService : IService<Appointment, long>
    {
        public IEnumerable<DateTime> GetTimesForDoctorAndDate(long id, DateTime date, IHttpRequestSender httpRequestSender);
        public Appointment SaveAppointment(Appointment appointment, IHttpRequestSender httpRequestSender);
        public IEnumerable<DateTime> GetTimesForSelectedDoctor(long patientId, IHttpRequestSender httpRequestSender);
        public IEnumerable<PriorityIntervalDTO> GetRecommendedTimes(PriorityDTO dto, IHttpRequestSender httpRequestSender);
        public bool MultipleAppoitments(AppointmentDTO dto, IHttpRequestSender httpRequestSender);
        public long SetSelectedDoctor(long patientId, IHttpRequestSender httpRequestSender);
    }
}
