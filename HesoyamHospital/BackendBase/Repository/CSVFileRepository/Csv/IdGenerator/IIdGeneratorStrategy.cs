using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.Csv.IdGenerator
{
    public interface IIdGeneratorStrategy<T, ID>
    {
        ID GetMaxId(IEnumerable<T> entities);
    }
}
