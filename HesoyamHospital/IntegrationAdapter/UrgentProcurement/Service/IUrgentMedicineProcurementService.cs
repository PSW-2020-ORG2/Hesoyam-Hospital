using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.PharmacyModel;
using Backend.Service;

namespace IntegrationAdapter.UrgentProcurement.Service
{
    public interface IUrgentMedicineProcurementService : IService<UrgentMedicineProcurement, long>
    {
        public IEnumerable<RegisteredPharmacy> GetPharmaciesByRequiredMedicine(UrgentMedicineProcurement urgentMedicine);
        public bool IsProcurementRequestSuccessfull(string pharmacyName, UrgentMedicineProcurement urgentMedicine);
    }
}
