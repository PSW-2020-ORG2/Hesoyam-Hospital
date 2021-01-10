using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using Backend.DTOs;

namespace Backend.Service.MedicalService
{
   public interface IAppointmentSchedulingService : IService<Appointment, long>
    {
        public IEnumerable<DateTime> GetTimesForDoctorAndDate(long id, DateTime date);
        public List<Doctor> GetDoctorsByType(string type);
        public Appointment SaveAppointment(Appointment appointment);
        public IEnumerable<DateTime> GetTimesForSelectedDoctor(Patient patient);
        public IEnumerable<PriorityIntervalDTO> GetRecommendedTimes(PriorityIntervalDTO dto);
        public bool MultipleAppoitments(Appointment appointment);
        public IEnumerable<PriorityIntervalDTO> GetByPriority(PriorityIntervalDTO dto);
        public IEnumerable<PriorityIntervalDTO> GetWhenPriorityIsDoctor(PriorityIntervalDTO dto);
        public IEnumerable<PriorityIntervalDTO> GetWhenPriorityIsInterval(PriorityIntervalDTO dto);

    }
}
