using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.MySQL.IdGenerator
{
    class DoctorIdGeneratorStrategy : IIdGeneratorStrategy<Doctor, UserID>
    {
        public UserID GetMaxId(IEnumerable<Doctor> entities)
            => entities.Count() == 0 ? UserID.defaultDoctor : entities.Max(entity => entity.GetId());
    }
}
