using Backend.Model.PatientModel;

namespace Authentication.Repository.Abstract
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord, long>
    {
    }
}
