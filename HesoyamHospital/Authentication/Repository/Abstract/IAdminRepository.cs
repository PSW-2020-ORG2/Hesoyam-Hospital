using Authentication.Model;

namespace Authentication.Repository.Abstract
{
    public interface IAdminRepository : IRepository<SystemAdmin, long>
    {
        public SystemAdmin GetByUsername(string username);
    }
}
