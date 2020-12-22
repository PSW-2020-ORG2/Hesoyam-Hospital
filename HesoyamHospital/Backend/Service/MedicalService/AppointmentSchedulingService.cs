using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;

namespace Backend.Service.MedicalService
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

        public List<Doctor> GetDoctorsByType(string type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetRecommendedTimes(PriorityIntervalDTO dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DateTime> GetTimesForDoctorAndDate(long id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DateTime> GetTimesForSelectedDoctor(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool MultipleAppoitments(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Appointment SaveAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
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
