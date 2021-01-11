using Backend.Model.PatientModel;
using System.Text;

namespace IntegrationAdapter.PrescribedMedicineReport
{
    public class PrescriptionTextGenerator
    {
        private readonly Therapy _therapy;
        public PrescriptionTextGenerator(Therapy therapy)
        {
            _therapy = therapy;
        }
        public string GeneratePrescriptionText()
        {
            StringBuilder text = new StringBuilder();
            InitializeHeader(text);
            WriteMedicines(text);
            WriteComment(text);
            return text.ToString();
        }
        private void WriteComment(StringBuilder text)
        {
            text.AppendLine(_therapy.Comment);
        }
        private void WriteMedicines(StringBuilder text)
        {
            text.AppendLine("Prescribed medicines: ");
            foreach (MedicalTherapy mt in _therapy.Prescription.MedicalTherapies)
            {
                text.AppendLine(mt.Medicine.Name);
            }
        }
        private void InitializeHeader(StringBuilder text)
        {
            text.AppendLine("Hesoyam Hospital\n");
            text.AppendLine("Prescription for patient: " + _therapy.Prescription.Patient.Name + " " + _therapy.Prescription.Patient.Surname + " " + _therapy.Prescription.Patient.Jmbg);
            text.AppendLine("Prescribed at: " + _therapy.Prescription.DateCreated);
            text.AppendLine("Prescription validity period: " + _therapy.TimeInterval.ToString());
        }
    }
}
