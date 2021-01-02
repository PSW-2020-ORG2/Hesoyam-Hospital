using Authentication.Model.UserModel;

namespace Authentication.Service.Abstract
{
    public interface IPatientService : IService<Patient, long>
    {
        public Patient Activate(long id);
        public Patient GetByUsername(string username);
        public Patient ChangeSelectedDoctor(long doctorId, long patientId);
    }
}
