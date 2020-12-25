using Backend.Model.UserModel;

namespace Documents.Repository.Abstract
{
    public interface IPatientRepository : IRepository<Patient, long>
    {
        public Patient GetPatientByUsername(string username);
    }
}
