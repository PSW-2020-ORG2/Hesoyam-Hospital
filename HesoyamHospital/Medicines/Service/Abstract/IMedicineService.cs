using Medicines.DTOs;
using Medicines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.Service.Abstract
{
    public interface IMedicineService : IService<Medicine, long>
    {
        public IEnumerable<Medicine> GetMedicineForDisease(Disease disease);
        public IEnumerable<Medicine> GetMedicineByIngredient(Ingredient ingredient);
        public Medicine GetMedicineByName(string name);
        public IEnumerable<Medicine> GetMedicinePendingApproval();
        public IEnumerable<Medicine> GetMedicinesByPartName(string partOfTheName);
        public IEnumerable<Medicine> GetMedicinesByRoomId(long roomId);
        public MedicineAvailabilityDTO GetMedicineAvailability(string medicineName, RegisteredPharmacyDTO registeredPharmacy);
    }
}
