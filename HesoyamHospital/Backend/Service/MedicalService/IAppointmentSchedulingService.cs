using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.MedicalService
{
   public interface IAppointmentSchedulingService : IService<Appointment, long>
    {
        public IEnumerable<DateTime> GetTimesForDoctorAndDate(long id, DateTime date);
        public List<Doctor> GetDoctorsByType(string type);
        public Appointment SaveAppointment(Appointment appointment);
        public IEnumerable<DateTime> GetTimesForSelectedDoctor(Patient patient);
        public IEnumerable<Appointment> GetRecommendedTimes(PriorityIntervalDTO dto);
        public bool MultipleAppoitments(Appointment appointment);
    
    }
}
