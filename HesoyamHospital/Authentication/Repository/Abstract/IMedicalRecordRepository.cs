using Authentication.Model;

namespace Authentication.Repository.Abstract
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord, long>
    {
        public MedicalRecord GetPatientMedicalRecordByPatientId(long patientId);
    }
}
