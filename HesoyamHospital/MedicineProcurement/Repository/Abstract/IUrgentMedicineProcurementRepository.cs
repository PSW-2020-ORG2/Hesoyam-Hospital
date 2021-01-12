using MedicineProcurement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineProcurement.Repository.Abstract
{
    public interface IUrgentMedicineProcurementRepository : IRepository<UrgentMedicineProcurement, long>
    {
        public IEnumerable<UrgentMedicineProcurement> GetAllUnconcluded();
    }
}
