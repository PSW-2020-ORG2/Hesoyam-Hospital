using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medicines.Model;

namespace Medicines.Repository.Abstract
{
    public interface IMedicineRepository : IRepository<Medicine, long>
    {
        public IEnumerable<Medicine> GetMedicineForDisease(Disease disease);

        public IEnumerable<Medicine> GetMedicineByIngredient(Ingredient ingredient);

        public Medicine GetMedicineByName(string name);

        public IEnumerable<Medicine> GetMedicinePendingApproval();

        public IEnumerable<Medicine> GetMedicinesByPartName(string partOfTheName);

        public IEnumerable<Medicine> GetMedicinesByRoomId(long roomId);
    }
}
