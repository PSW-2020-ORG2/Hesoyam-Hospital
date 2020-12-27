using Authentication.Model.UserModel;
using Appointments.Repository;
using Appointments.Service.Abstract;
using System.Collections.Generic;

namespace Appointments.Service
{
    public class PatientService : IPatientService
    {
        readonly PatientRepository _patientRepository;

        public PatientService(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAll()
            => _patientRepository.GetAll();

        public Patient GetByID(long id)
            => _patientRepository.GetByID(id);

        public Patient GetByUsername(string username)
            => _patientRepository.GetPatientByUsername(username);

        public Patient Create(Patient entity)
            => _patientRepository.Create(entity);

        public void Delete(Patient entity)
            => _patientRepository.Delete(entity);

        public void Update(Patient entity)
            => _patientRepository.Update(entity);

    }
}
