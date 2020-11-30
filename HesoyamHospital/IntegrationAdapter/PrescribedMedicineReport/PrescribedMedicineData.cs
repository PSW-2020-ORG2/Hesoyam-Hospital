using Backend.Model.PatientModel;
using System.Collections.Generic;

namespace IntegrationAdapter.MedicineReport
{
    public class PrescribedMedicineData
    {
        public Dictionary<string, int> PrescribedMedicineCount;
        public Dictionary<MedicineType, int> PrescribedMedicineTypeCount;
    }
}
