using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Scheduling.Service
{
    public class AppointmentSchedulingService : IAppointmentSchedulingService
    {
        public Appointment Create(Appointment entity)
        {
            throw new NotImplementedException();
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

        public IEnumerable<Doctor> GetDoctorsByType(string type)
        {
            return null;
        }

        public IEnumerable<TimeInterval> GetTimesForDoctorAndDate(long id, DateTime date)
        {
            return null;
        }

        public Appointment SaveAppointment(Appointment appointment)
        {
            return null;
        }

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
