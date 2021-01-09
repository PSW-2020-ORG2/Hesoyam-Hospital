using Backend.Model.PatientModel;
using Backend.Service.MedicalService;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IntegrationAdapter.MedicineReport
{
    public class PrescribedMedicineReportGenerator
    {
        private readonly TherapyService _therapyService;
        private readonly string _filePath;
        public PrescribedMedicineReportGenerator(TherapyService therapyService, string filePath)
        {
            _therapyService = therapyService;
            _filePath = filePath;
        }

        public void GenerateReport(TimeInterval interval)
        {
            List<Therapy> therapies = _therapyService.GetTherapyByDatePrescribed(interval).ToList();
            PrescribedMedicineData data = AnalyzeTherapies(therapies);
            InitializeHeader(interval);
            WriteMedicineCount(data.PrescribedMedicineCount);
            WriteMedicineTypeCount(data.PrescribedMedicineTypeCount);
        }

        private void WriteMedicineTypeCount(Dictionary<MedicineType, int> prescribedMedicineTypeCount)
        {
            List<Tuple<MedicineType, int>> medicineSortedByTypeCount = SortMedicineByTypeCount(prescribedMedicineTypeCount);
            List<Tuple<MedicineType, int>> topFive = medicineSortedByTypeCount.Take(10).ToList();
            List<Tuple<MedicineType, int>> other = medicineSortedByTypeCount.Skip(10).Take(medicineSortedByTypeCount.Count() - 10).ToList();
            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine("\nMost prescribed medicine types:");
                WriteMedicineTypes(topFive, sw);
                if (other.Count() > 0)
                {
                    sw.WriteLine("\nOther prescribed medicine types:");
                    WriteMedicineTypes(other, sw);
                }
            }
        }

        private void WriteMedicineCount(Dictionary<string, int> prescribedMedicineCount)
        {
            List<Tuple<string, int>> medicineSortedByCount = SortMedicineByCount(prescribedMedicineCount);
            List<Tuple<string, int>> topTen = medicineSortedByCount.Take(10).ToList();
            List<Tuple<string, int>> other = medicineSortedByCount.Skip(10).Take(medicineSortedByCount.Count() - 10).ToList();
            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine("\nTotal number of different medicines prescribed: " + medicineSortedByCount.Count() + ".");
                sw.WriteLine("\nMost prescribed medicines:");
                WriteMedicine(topTen, sw);
                if (other.Count() > 0)
                {
                    sw.WriteLine("\nOther prescribed medicines:");
                    WriteMedicine(other, sw);
                }
            }
        }

        private void WriteMedicine(List<Tuple<string, int>> other, StreamWriter sw)
        {
            foreach (Tuple<string, int> pair in other)
            {
                sw.WriteLine(pair.Item1 + " : " + pair.Item2);
            }
        }
        private void WriteMedicineTypes(List<Tuple<MedicineType, int>> other, StreamWriter sw)
        {
            foreach (Tuple<MedicineType, int> pair in other)
            {
                sw.WriteLine(pair.Item1 + " : " + pair.Item2);
            }
        }

        private void InitializeHeader(TimeInterval interval)
        {
            using (StreamWriter sw = File.CreateText(_filePath))
            {
                StringBuilder header = new StringBuilder();
                header.Append("Hesoyam Hospital\n");
                header.Append("Prescribed medicine report for period: " + interval.ToString());
                sw.WriteLine(header.ToString());
            }
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
