using Medicines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.Util
{
    public class PrescribedMedicineData
    {
        public Dictionary<string, int> PrescribedMedicineCount;
        public Dictionary<MedicineType, int> PrescribedMedicineTypeCount;
    }
}
