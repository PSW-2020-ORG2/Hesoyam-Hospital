using Appointments.Model.UserModel;

namespace Appointments.Service.Abstract
{
    public interface IPatientService : IService<Patient, long>
    {
        public Patient GetByUsername(string username);
    }
}
