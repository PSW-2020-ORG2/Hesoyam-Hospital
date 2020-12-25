using Backend.Model.UserModel;

namespace Documents.Service.Abstract
{
    public interface IPatientService : IService<Patient, long>
    {
        public Patient GetByUsername(string username);
        public Patient ChangeSelectedDoctor(long doctorId, long patientId);
    }
}
