using Backend.Model.UserModel;

namespace Authentication.Service.Abstract
{
    public interface IPatientService : IService<Patient, long>
    {
        public Patient Activate(long id);
    }
}
