using Medicines.Model;
using Medicines.Service;
using Medicines.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Util
{
    public class PrescribedMedicineReportGenerator
    {
        private readonly ITherapyService _therapyService;
        public PrescribedMedicineReportGenerator(ITherapyService therapyService)
        {
            _therapyService = therapyService;
        }

        public string GenerateReport(TimeInterval interval)
        {
            List<Therapy> therapies = _therapyService.GetTherapyByDatePrescribed(interval).ToList();
            PrescribedMedicineData data = AnalyzeTherapies(therapies);
            StringBuilder text = new StringBuilder();
            InitializeHeader(text, interval);
            WriteMedicineCount(text, data.PrescribedMedicineCount);
            WriteMedicineTypeCount(text, data.PrescribedMedicineTypeCount);
            return text.ToString();
        }

        private void WriteMedicineTypeCount(StringBuilder text, Dictionary<MedicineType, int> prescribedMedicineTypeCount)
        {
            List<Tuple<MedicineType, int>> medicineSortedByTypeCount = SortMedicineByTypeCount(prescribedMedicineTypeCount);
            List<Tuple<MedicineType, int>> topFive = medicineSortedByTypeCount.Take(10).ToList();
            List<Tuple<MedicineType, int>> other = medicineSortedByTypeCount.Skip(10).Take(medicineSortedByTypeCount.Count() - 10).ToList();
            text.Append("\nMost prescribed medicine types:");
            WriteMedicineTypes(text, topFive);
            if (other.Any())
            {
                text.Append("\nOther prescribed medicine types:");
                WriteMedicineTypes(text, other);
            }
        }

        private void WriteMedicineCount(StringBuilder text, Dictionary<string, int> prescribedMedicineCount)
        {
            List<Tuple<string, int>> medicineSortedByCount = SortMedicineByCount(prescribedMedicineCount);
            List<Tuple<string, int>> topTen = medicineSortedByCount.Take(10).ToList();
            List<Tuple<string, int>> other = medicineSortedByCount.Skip(10).Take(medicineSortedByCount.Count() - 10).ToList();
            text.Append("\nTotal number of different medicines prescribed: " + medicineSortedByCount.Count() + ".");
            text.Append("\nMost prescribed medicines:");
            WriteMedicine(text, topTen);
            if (other.Any())
            {
                text.Append("\nOther prescribed medicines:");
                WriteMedicine(text, other);
            }
        }

        private void WriteMedicine(StringBuilder text, List<Tuple<string, int>> other)
        {
            foreach (Tuple<string, int> pair in other)
            {
                text.Append(pair.Item1 + " : " + pair.Item2);
            }
        }
        private void WriteMedicineTypes(StringBuilder text, List<Tuple<MedicineType, int>> other)
        {
            foreach (Tuple<MedicineType, int> pair in other)
            {
                text.Append(pair.Item1 + " : " + pair.Item2);
            }
        }

        private void InitializeHeader(StringBuilder text, TimeInterval interval)
        {
            text.Append("Hesoyam Hospital\n");
            text.Append("Prescribed medicine report for period: " + interval.ToString());
        }

        private List<Tuple<MedicineType, int>> SortMedicineByTypeCount(Dictionary<MedicineType, int> prescribedMedicineTypeCount)
        {
            List<Tuple<MedicineType, int>> list = prescribedMedicineTypeCount.Select(x => new Tuple<MedicineType, int>(x.Key, x.Value)).ToList();
            list = list.OrderByDescending(i => i.Item2).ToList();
            return list;
        }

        private List<Tuple<string, int>> SortMedicineByCount(Dictionary<string, int> prescribedMedicineCount)
        {
            List<Tuple<string, int>> list = prescribedMedicineCount.Select(x => new Tuple<string, int>(x.Key, x.Value)).ToList();
            list = list.OrderByDescending(i => i.Item2).ToList();
            return list;
        }

        private PrescribedMedicineData AnalyzeTherapies(List<Therapy> therapies)
        {
            PrescribedMedicineData data = new PrescribedMedicineData();
            data.PrescribedMedicineCount = CountMedicine(therapies);
            data.PrescribedMedicineTypeCount = CountMedicineTypes(therapies);
            return data;
        }

        private Dictionary<string, int> CountMedicine(List<Therapy> therapies)
        {
            Dictionary<string, int> medicineCount = new Dictionary<string, int>();
            foreach (Therapy t in therapies)
            {
                foreach (MedicalTherapy mt in t.Prescription.MedicalTherapies)
                {
                    if (mt.Medicine == null) continue;

                    if (medicineCount.ContainsKey(mt.Medicine.Name))
                        medicineCount[mt.Medicine.Name] += 1;
                    else
                        medicineCount[mt.Medicine.Name] = 1;
                }
            }
            return medicineCount;
        }

        private Dictionary<MedicineType, int> CountMedicineTypes(List<Therapy> therapies)
        {
            Dictionary<MedicineType, int> typeCount = new Dictionary<MedicineType, int>();
            foreach (Therapy t in therapies)
            {
                foreach (MedicalTherapy mt in t.Prescription.MedicalTherapies)
                {
                    if (mt.Medicine == null) continue;

                    if (typeCount.ContainsKey(mt.Medicine.MedicineType))
                        typeCount[mt.Medicine.MedicineType] += 1;
                    else
                        typeCount[mt.Medicine.MedicineType] = 1;
                }
            }
            return typeCount;
        }
    }
}
