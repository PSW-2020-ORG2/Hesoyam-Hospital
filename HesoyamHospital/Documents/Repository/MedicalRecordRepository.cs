using Backend.Model.PatientModel;
using Documents.Repository.Abstract;
using Documents.Repository.SQLRepository.Base;
using System.Linq;

namespace Documents.Repository
{
    public class MedicalRecordRepository : SQLRepository<MedicalRecord, long>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(ISQLStream<MedicalRecord> stream) : base(stream)
        {
        }

        public MedicalRecord GetPatientMedicalRecordByPatientId(long patientId)
            => GetAll().SingleOrDefault(medicalRecord => medicalRecord.Patient.Id.Equals(patientId));
    }
}