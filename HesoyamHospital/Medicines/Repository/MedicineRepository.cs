using Medicines.Model;
using Medicines.Repository.Abstract;
using Medicines.Repository.SQLRepository.Base;
using System.Collections.Generic;
using System.Linq;

namespace Medicines.Repository
{
    public class MedicineRepository : SQLRepository<Medicine, long>, IMedicineRepository
    {
        public MedicineRepository(ISQLStream<Medicine> stream) : base(stream)
        {
        }

        public IEnumerable<Medicine> GetMedicineForDisease(Disease disease)
            => GetAll().Where(med => med.UsedFor.Contains(new DiseaseMedicine(disease, med)));

        public IEnumerable<Medicine> GetMedicineByIngredient(Ingredient ingredient)
            => GetAll().Where(med => med.Ingredient.Contains(ingredient));

        public Medicine GetMedicineByName(string name)
            => GetAll().SingleOrDefault(med => med.Name == name);

        public IEnumerable<Medicine> GetMedicinesByRoomId(long roomId)
        {
            List<Medicine> result = new List<Medicine>();
            List<Medicine> medicines = GetAll().ToList();
            foreach (Medicine m in medicines)
                if (m.RoomID == roomId)
                    result.Add(m);

            return result;
        }

        public IEnumerable<Medicine> GetMedicinesByPartName(string partOfTheName)
            => GetAll().Where(med => med.Name.Contains(partOfTheName));

        public IEnumerable<Medicine> GetMedicinePendingApproval()
            => GetAll().Where(med => med.IsValid == false);
    }
}
