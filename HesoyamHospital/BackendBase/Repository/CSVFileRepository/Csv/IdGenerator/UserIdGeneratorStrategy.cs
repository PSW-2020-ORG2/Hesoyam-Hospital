using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.Csv.IdGenerator
{
    class UserIdGeneratorStrategy : IIdGeneratorStrategy<User, UserID>
    {
        public UserID GetMaxId(IEnumerable<User> entities)
        {
            //TODO: User ID Generator Note:
            //UserRepository never calls this method because every patient's, manager's, secretary's and doctor's ID is generated in their respective generators.
            return new UserID("x0");
        }
    }
}
