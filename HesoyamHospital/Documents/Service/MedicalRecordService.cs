using Authentication.Model.MedicalRecordModel;
using Documents.Repository;
using System.Collections.Generic;

namespace Documents.Service.Abstract
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly MedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(MedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public MedicalRecord GetPatientMedicalRecordByPatientId(long patientId)
           => _medicalRecordRepository.GetPatientMedicalRecordByPatientId(patientId);

        public IEnumerable<MedicalRecord> GetAll()
            => _medicalRecordRepository.GetAll();

        public MedicalRecord GetByID(long id)
            => _medicalRecordRepository.GetByID(id);

        public MedicalRecord Create(MedicalRecord entity)
            => _medicalRecordRepository.Create(entity);

        public void Delete(MedicalRecord entity)
            => _medicalRecordRepository.Delete(entity);

        public void Update(MedicalRecord entity)
            => _medicalRecordRepository.Update(entity);
    }
}
