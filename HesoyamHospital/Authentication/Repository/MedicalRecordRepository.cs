using Authentication.Repository.Abstract;
using Authentication.Repository.SQLRepository.Base;
using Authentication.Model.MedicalRecordModel;
using System.Linq;

namespace Authentication.Repository
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