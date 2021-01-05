using Authentication.Model;
using Authentication.Repository.Abstract;
using Authentication.Repository.SQLRepository.Base;
using System.Linq;

namespace Authentication.Repository
{
    public class AdminRepository : SQLRepository<SystemAdmin, long>, IAdminRepository
    {
        public AdminRepository(ISQLStream<SystemAdmin> stream) : base(stream)
        {
        }

        public SystemAdmin GetByUsername(string username)
            => GetAll().FirstOrDefault(admin => admin.UserName.Equals(username));
    }
}
