using System.Collections.Generic;
using MedicineProcurement.DTOs;
using MedicineProcurement.Model;

namespace MedicineProcurement.Service.Abstract
{
    public interface IUrgentMedicineProcurementService : IService<UrgentMedicineProcurement, long>
    {
        public IEnumerable<RegisteredPharmacyDTO> GetPharmaciesByRequiredMedicine(List<RegisteredPharmacyDTO> allPharmacies, UrgentMedicineProcurement urgentMedicine);
        public bool IsProcurementRequestSuccessfull(RegisteredPharmacyDTO pharmacy, long urgentMedicineId);
        public IEnumerable<UrgentMedicineProcurement> GetAllUnconcluded();
    }
}
