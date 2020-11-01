using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.MySQL.IdGenerator
{
    class SecretaryIdGeneratorStrategy : IIdGeneratorStrategy<Secretary, UserID>
    {
        public UserID GetMaxId(IEnumerable<Secretary> entities)
            => entities.Count() == 0 ? UserID.defaultSecretary : entities.Max(entity => entity.GetId());
    }
}
