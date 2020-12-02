using Backend.Model.PatientModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Appointments.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IPatientRepository _patientRepository;

        public AppointmentService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
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

        public IEnumerable<Appointment> GetAllByPatient(long patientId)
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

        public void Validate(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
