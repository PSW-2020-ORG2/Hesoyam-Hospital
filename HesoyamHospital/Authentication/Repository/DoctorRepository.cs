using Authentication.Model.UserModel;
using Authentication.Repository.Abstract;
using Authentication.Repository.SQLRepository.Base;

namespace Authentication.Repository
{
    public class DoctorRepository : SQLRepository<Doctor, long>, IDoctorRepository
    {
        public DoctorRepository(ISQLStream<Doctor> stream) : base(stream)
        {
        }
    }
}
