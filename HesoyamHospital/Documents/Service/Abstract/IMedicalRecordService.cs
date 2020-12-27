using Authentication.Model.MedicalRecordModel;

namespace Documents.Service.Abstract
{
    public interface IMedicalRecordService : IService<MedicalRecord, long>
    {
        public MedicalRecord GetPatientMedicalRecordByPatientId(long patientId);
    }
}
