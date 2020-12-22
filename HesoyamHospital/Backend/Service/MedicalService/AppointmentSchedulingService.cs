using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using System;
using System.Collections.Generic;

namespace Backend.Service.MedicalService
{
    public class AppointmentSchedulingService : IAppointmentSchedulingService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        public readonly long APPOINTMENT_DURATION_MINUTES = 30;

        public AppointmentSchedulingService(IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
        }

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
