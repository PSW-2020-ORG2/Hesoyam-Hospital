using Authentication.Model.UserModel;
using Feedbacks.Repository;
using Feedbacks.Service.Abstract;
using System.Collections.Generic;

namespace Feedbacks.Service
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

        public Patient Create(Patient entity)
            => _patientRepository.Create(entity);

        public void Delete(Patient entity)
            => _patientRepository.Delete(entity);

        public void Update(Patient entity)
            => _patientRepository.Update(entity);
    }
}
