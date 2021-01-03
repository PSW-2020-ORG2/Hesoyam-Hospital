using Appointments.DTOs;
using Appointments.Mappers;
using Appointments.Model;
using Appointments.Repository.Abstract;
using Appointments.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Appointments.Service
{
    public class AppointmentSchedulingService : IAppointmentSchedulingService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ITimeTableRepository _timeTableRepository;
        public readonly long APPOINTMENT_DURATION_MINUTES = 30;

        public AppointmentSchedulingService(IAppointmentRepository appointmentRepository, ITimeTableRepository timeTableRepository)
        {
            _appointmentRepository = appointmentRepository;
            _timeTableRepository = timeTableRepository;
        }

        public Appointment Create(Appointment entity)
        {
            return _appointmentRepository.Create(entity);
        }

        public long SetSelectedDoctor(long patientId, IHttpRequestSender httpRequestSender)
            => httpRequestSender.GetSelectedDoctorId(patientId);


        public Appointment SaveAppointment(Appointment appointment, IHttpRequestSender httpRequestSender)
        {
            TimeTable timeTable = _timeTableRepository.GetByID(httpRequestSender.GetTimeTableIdForDoctorId(appointment.DoctorInAppointmentId));
            if (timeTable == null || timeTable.GetShiftByDate(appointment.TimeInterval.StartTime) == null) return null;
            timeTable.GetShiftByDate(appointment.TimeInterval.StartTime).Appointments.Add(appointment);
            _timeTableRepository.Update(timeTable);
            return appointment;
        }

        public IEnumerable<DateTime> GetTimesForDoctorAndDate(long id, DateTime date, IHttpRequestSender httpRequestSender)
        {
            TimeTable timeTable = _timeTableRepository.GetByID(httpRequestSender.GetTimeTableIdForDoctorId(id));
            if (timeTable == null || timeTable.GetShiftByDate(date) == null) return new List<DateTime>();
            return timeTable.GetShiftByDate(date).GetAvailableTimes(APPOINTMENT_DURATION_MINUTES);
        }

        public IEnumerable<DateTime> GetTimesForSelectedDoctor(long patientId, IHttpRequestSender httpRequestSender)
        {
            TimeTable timeTable = _timeTableRepository.GetByID(httpRequestSender.GetTimeTableIdForSelectedDoctor(patientId));
            if (timeTable == null || timeTable.Shifts == null) return new List<DateTime>();
            return timeTable.GetFirstTenAppointments(APPOINTMENT_DURATION_MINUTES);
        }

        public IEnumerable<PriorityIntervalDTO> GetRecommendedTimes(PriorityDTO dto, IHttpRequestSender httpRequestSender)
        {
            TimeTable timeTable = _timeTableRepository.GetByID(httpRequestSender.GetTimeTableIdForDoctorId(dto.Id));
            if (timeTable == null) return GetByPriority(dto, httpRequestSender).ToList();
            List<DateTime> appointments = timeTable.GetFirstAvailableTimeForInterval(APPOINTMENT_DURATION_MINUTES, dto.StartDate, dto.EndDate);
            if (appointments != null && appointments.Count != 0) return PriorityIntervalMapper.ListToDtoListForOneDoctor(dto.Id, appointments, httpRequestSender);
            return GetByPriority(dto, httpRequestSender).ToList();
        }

        public IEnumerable<PriorityIntervalDTO> GetByPriority(PriorityDTO dto, IHttpRequestSender httpRequestSender)
        {
            if (dto.PriorityDoctor) return GetWhenPriorityIsDoctor(dto, httpRequestSender);
            return GetWhenPriorityIsInterval(dto, httpRequestSender);
        }

        public IEnumerable<PriorityIntervalDTO> GetWhenPriorityIsDoctor(PriorityDTO dto, IHttpRequestSender httpRequestSender)
        {
            TimeTable timeTable = _timeTableRepository.GetByID(httpRequestSender.GetTimeTableIdForDoctorId(dto.Id));
            if (timeTable == null) return new List<PriorityIntervalDTO>();
            List<DateTime> appointments = timeTable.GetFirstTenAppointments(APPOINTMENT_DURATION_MINUTES).ToList();
            if (appointments != null && appointments.Count != 0) return PriorityIntervalMapper.ListToDtoListForOneDoctor(dto.Id, appointments, httpRequestSender);
            return new List<PriorityIntervalDTO>();
        }

        public IEnumerable<PriorityIntervalDTO> GetWhenPriorityIsInterval(PriorityDTO dto, IHttpRequestSender httpRequestSender)
        {
            List<PriorityIntervalDTO> appointments = new List<PriorityIntervalDTO>();
            List<long> doctorsIds = httpRequestSender.GetSameSpecializationDoctorIds(dto.Id);
            if (doctorsIds.Count == 0) return appointments;
            foreach (long doctorId in doctorsIds)
            {
                TimeTable timeTable = _timeTableRepository.GetByID(httpRequestSender.GetTimeTableIdForDoctorId(dto.Id));
                if (timeTable == null) break;
                dto.Id = doctorId;
                appointments.AddRange(PriorityIntervalMapper.ListToDtoListForOneDoctor(doctorId, timeTable.GetAvailableTimesForInterval(APPOINTMENT_DURATION_MINUTES, dto.StartDate, dto.EndDate).ToList(), httpRequestSender));
                if (appointments.Count >= 3) return appointments;
            }
            return appointments;
        }

        public bool MultipleAppoitments(AppointmentDTO dto, IHttpRequestSender httpRequestSender)
        {
            TimeTable timeTable = _timeTableRepository.GetByID(httpRequestSender.GetTimeTableIdForDoctorId(dto.DoctorId));
            if (timeTable == null || timeTable.GetShiftByDate(dto.DateAndTime) == null) return false;
            return timeTable.GetShiftByDate(dto.DateAndTime).PatientAlreadyScheduledInThisShift(dto.PatientId);
        }

        public void Delete(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
