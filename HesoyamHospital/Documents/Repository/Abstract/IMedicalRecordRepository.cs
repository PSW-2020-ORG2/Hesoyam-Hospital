using Backend.Model.PatientModel;

namespace Documents.Repository.Abstract
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord, long>
    {
        public MedicalRecord GetPatientMedicalRecordByPatientId(long patientId);
    }
}
