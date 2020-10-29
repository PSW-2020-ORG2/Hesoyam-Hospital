using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.Csv.IdGenerator
{
    class ManagerIdGeneratorStrategy : IIdGeneratorStrategy<Manager, UserID>
    {
        public UserID GetMaxId(IEnumerable<Manager> entities)
        => entities.Count() == 0 ? UserID.defaultManager : entities.Max(entity => entity.GetId());
    }
}
