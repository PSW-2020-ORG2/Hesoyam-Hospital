using Backend.Model.PharmacyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IUrgentMedicineProcurementRepository : IRepository<UrgentMedicineProcurement, long>
    {
        public IEnumerable<UrgentMedicineProcurement> GetAllUnconcluded();
    }
}
