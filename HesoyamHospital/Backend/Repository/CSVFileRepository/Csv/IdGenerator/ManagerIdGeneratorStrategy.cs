using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.CSVFileRepository.Csv.IdGenerator
{
    class ManagerIdGeneratorStrategy : IIdGeneratorStrategy<Manager, UserID>
    {
        public UserID GetMaxId(IEnumerable<Manager> entities)
        => entities.Count() == 0 ? UserID.defaultManager : entities.Max(entity => entity.GetId());
    }
}
