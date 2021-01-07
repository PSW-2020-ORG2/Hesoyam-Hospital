using Authentication.Model;

namespace Authentication.Repository.Abstract
{
    public interface IPatientRepository : IRepository<Patient, long>
    {
        public Patient GetPatientByUsername(string username);
    }
}
