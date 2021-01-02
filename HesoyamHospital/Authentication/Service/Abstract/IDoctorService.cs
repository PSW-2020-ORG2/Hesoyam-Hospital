using Authentication.Model.UserModel;
using System.Collections.Generic;

namespace Authentication.Service.Abstract
{
    public interface IDoctorService : IService<Doctor, long>
    {
        public IEnumerable<long> GetAllDoctorIds();
        public string GetUsername(long doctorId);
    }
}
