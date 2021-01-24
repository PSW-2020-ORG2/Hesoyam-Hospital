using Medicines.DTOs;
using Medicines.Model;
using Medicines.Util;
using System.Collections.Generic;

namespace Medicines.Service.Abstract
{
    public interface ITherapyService : IService<Therapy, long>
    {
        public void SendTherapyToPharmacy(Therapy therapy, string patientFullName, RegisteredPharmacyDTO registeredPharmacy);
        public IEnumerable<Therapy> GetTherapyByDatePrescribed(TimeInterval dateRange);
    }
}
