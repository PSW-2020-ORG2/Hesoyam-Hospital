using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.CSVFileRepository.Csv.IdGenerator
{
    class PatientIdGeneratorStrategy : IIdGeneratorStrategy<Patient, UserID>
    {
        public UserID GetMaxId(IEnumerable<Patient> entities)
        => entities.Count() == 0 ? UserID.defaultPatient : entities.Max(entity => entity.GetId());
    }
}
