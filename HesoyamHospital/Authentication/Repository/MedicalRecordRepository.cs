using Authentication.Repository.Abstract;
using Authentication.Repository.SQLRepository.Base;
using Backend.Model.PatientModel;

namespace Authentication.Repository
{
    public class MedicalRecordRepository : SQLRepository<MedicalRecord, long>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(ISQLStream<MedicalRecord> stream) : base(stream)
        {
        }
    }
}