using Documents.DTOs;
using Documents.Model;
using Documents.Service.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Documents.Mappers
{
    public static class PrescriptionMapper
    {
        public static PrescriptionDTO PrescriptionToPrescriptionDTO(Prescription prescription, IHttpRequestSender httpRequestSender)
        {
            PrescriptionDTO res = new PrescriptionDTO
            {
                DateTimeCreated = prescription.DateCreated.ToString("dd.MM.yyyy"),
                DoctorFullName = httpRequestSender.GetDoctorFullName(prescription.DoctorId),
                DoctorSpecialisation = httpRequestSender.GetDoctorSpecialisation(prescription.DoctorId),
                Diagnosis = prescription.Diagnosis != null ? prescription.Diagnosis.DiagnosisName : "UNDEFINED",
                Therapies = GetTherapies(prescription)
            };
            return res;
        }

        public static List<TherapyDTO> GetTherapies(Prescription prescription)
        {
            List<TherapyDTO> therapies = new List<TherapyDTO>();
            foreach (MedicalTherapy therapy in prescription.MedicalTherapies)
            {
                TherapyDTO t = new TherapyDTO
                {
                    MedicineName = therapy.Medicine != null ? therapy.Medicine.Name : "UNDEFINED"
                };
                if (therapy.Dose != null && therapy.Dose.Dosage != null && therapy.Dose.Dosage.Count > 0)
                {
                    t.TherapyTime = therapy.Dose.Dosage[0].TherapyTime.ToString();
                    t.Quantity = therapy.Dose.Dosage[0].Quantity;
                }
                else
                {
                    t.TherapyTime = "UNDEFINED";
                    t.Quantity = 0;
                }
                therapies.Add(t);
            }
            return therapies;
        }
    }
}
