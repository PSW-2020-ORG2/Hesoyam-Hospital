using Authentication.Model.UserModel;

namespace Appointments.Repository.Abstract
{
    public interface IPatientRepository : IRepository<Patient, long>
    {
        public Patient GetPatientByUsername(string username);
    }
}
