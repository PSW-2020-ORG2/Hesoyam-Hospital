using Authentication.Model.UserModel;

namespace Authentication.Repository.Abstract
{
    public interface IPatientRepository : IRepository<Patient, long>
    {
        public Patient GetPatientByUsername(string username);
    }
}
