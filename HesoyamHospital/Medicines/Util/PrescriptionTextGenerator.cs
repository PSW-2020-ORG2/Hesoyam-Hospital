using Medicines.Model;
using System.Text;

namespace Medicines.Util
{
    public class PrescriptionTextGenerator
    {
        public PrescriptionTextGenerator()
        {
        }
        public string GeneratePrescriptionText(Therapy therapy, string patientFullName)
        {
            StringBuilder text = new StringBuilder();
            InitializeHeader(therapy, patientFullName, text);
            WriteMedicines(therapy, text);
            WriteComment(therapy, text);
            return text.ToString();
        }
        private void WriteComment(Therapy therapy, StringBuilder text)
        {
            text.AppendLine("\n" + therapy.Comment);
        }
        private void WriteMedicines(Therapy therapy, StringBuilder text)
        {
            text.AppendLine("Prescribed medicines: ");
            foreach (MedicalTherapy mt in therapy.Prescription.MedicalTherapies)
            {
                text.AppendLine(mt.Medicine.Name);
            }
        }
        private void InitializeHeader(Therapy therapy, string patientFullName, StringBuilder text)
        {
            text.AppendLine("Hesoyam Hospital\n");
            text.AppendLine("Prescription for patient: " + patientFullName);
            text.AppendLine("Prescribed at: " + therapy.Prescription.DateCreated);
            text.AppendLine("Prescription validity period: " + therapy.TimeInterval.ToString());
        }
    }
}
