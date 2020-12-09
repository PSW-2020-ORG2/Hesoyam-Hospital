using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Scheduling.Service
{
    public interface IAppointmentSchedulingService : IService<Appointment, long>
    {
        public IEnumerable<DateTime> GetTimesForDoctorAndDate(long id, DateTime date);
        public List<Doctor> GetDoctorsByType(string type);
        public Appointment SaveAppointment(Appointment appointment);
        public IEnumerable<DateTime> GetTimesForSelectedDoctor(Patient patient);
        public IEnumerable<PriorityIntervalDTO> GetRecommendedTimes(PriorityDTO dto);
        public bool MultipleAppoitments(AppointmentDTO dto);
    }
}
