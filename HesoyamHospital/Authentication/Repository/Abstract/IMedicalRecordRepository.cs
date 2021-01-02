using Authentication.Model.MedicalRecordModel;

namespace Authentication.Repository.Abstract
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord, long>
    {
        public MedicalRecord GetPatientMedicalRecordByPatientId(long patientId);
    }
}
