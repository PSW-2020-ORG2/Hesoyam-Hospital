using Backend.Model.UserModel;
using Feedbacks.Repository.Abstract;
using Feedbacks.Repository.SQLRepository.Base;

namespace Feedbacks.Repository
{
    public class DoctorRepository : SQLRepository<Doctor, long>, IDoctorRepository
    {
        public DoctorRepository(ISQLStream<Doctor> stream) : base(stream)
        {
        }
    }
}
