using Authentication.Model.UserModel;
using Feedbacks.Repository.Abstract;
using Feedbacks.Repository.SQLRepository.Base;

namespace Feedbacks.Repository
{
    public class PatientRepository : SQLRepository<Patient, long>, IPatientRepository
    {
        public PatientRepository(ISQLStream<Patient> stream) : base(stream)
        {
        }
    }
}
