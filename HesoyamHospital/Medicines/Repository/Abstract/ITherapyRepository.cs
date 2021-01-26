using Medicines.Model;
using Medicines.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.Repository.Abstract
{
    public interface ITherapyRepository : IRepository<Therapy, long>
    {
        public IEnumerable<Therapy> GetTherapyByDatePrescribed(TimeInterval dateRange);
    }
}
