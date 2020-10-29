using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    class PrescriptionConverter : ICSVConverter<Prescription>
    {
        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";";
        private readonly string _secondaryListDelimiter ="?";
        private readonly string _thirdListDelimiter = "~";
        private readonly string _fourthListDelimiter = "#";
        private readonly string _dateTimeFormat = "dd.MM.yyyy. HH:mm";

        public PrescriptionConverter()
        {
        }

        public Prescription ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            Dictionary<Medicine, TherapyDose> medicine = GetMedicines(tokens[3]);

            Prescription p = new Prescription(long.Parse(tokens[0]),
                                                (PrescriptionStatus)Enum.Parse(typeof(PrescriptionStatus), tokens[1]),
                                                new Doctor(new UserID(tokens[2])),
                                                medicine);

            return p;
        }

        private Dictionary<Medicine, TherapyDose> GetMedicines(string v)
        {
            string[] tokens = v.Split(_listDelimiter.ToCharArray());
            Dictionary<Medicine, TherapyDose> retVal = new Dictionary<Medicine, TherapyDose>();

            foreach(string token in tokens)
            {
                string[] medicineTokens = token.Split(_secondaryListDelimiter.ToCharArray());

                if (string.IsNullOrEmpty(medicineTokens[0]))
                    break;

                Medicine medicine = new Medicine(long.Parse(medicineTokens[0]));
                TherapyDose therapyDose = GetTherapyDose(medicineTokens[1]);
                retVal.Add(medicine, therapyDose);
            }
            
            return retVal;
        }

        private TherapyDose GetTherapyDose(string v)
        {
            string[] tokens = v.Split(_thirdListDelimiter.ToCharArray());
            Dictionary<TherapyTime, double> dosage = new Dictionary<TherapyTime, double>();

            foreach(string token in tokens)
            {
                string[] dosageTokens = token.Split(_fourthListDelimiter.ToCharArray());

                if (string.IsNullOrEmpty(dosageTokens[0]))
                    break;

                dosage.Add((TherapyTime)Enum.Parse(typeof(TherapyTime), dosageTokens[0]), double.Parse(dosageTokens[1]));
            }

            TherapyDose therapyDose = new TherapyDose(dosage);
            return therapyDose;
        }

        public string ConvertEntityToCSV(Prescription prescription)
            => string.Join(_delimiter,
                            prescription.GetId(),
                            prescription.Status,
                            prescription.Doctor.GetId(),
                            GetDictionaryCSV(prescription.Medicine));

        private string GetDictionaryCSV(Dictionary<Medicine, TherapyDose> dict)
            => string.Join(_listDelimiter, dict.Select(d => d.Key.GetId() + _secondaryListDelimiter + GetTherapyDoseCSV(d.Value)));

        private string GetTherapyDoseCSV(TherapyDose dose)
            => string.Join(_thirdListDelimiter, dose.Dosage.Select(v => v.Key + _fourthListDelimiter + v.Value));
    }
}
