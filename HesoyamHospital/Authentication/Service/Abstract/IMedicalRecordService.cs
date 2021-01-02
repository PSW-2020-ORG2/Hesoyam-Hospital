using Authentication.Model.MedicalRecordModel;

namespace Authentication.Service.Abstract
{
    public interface IMedicalRecordService : IService<MedicalRecord, long>
    {
        public MedicalRecord GetPatientMedicalRecordByPatientId(long patientId);
    }
}
