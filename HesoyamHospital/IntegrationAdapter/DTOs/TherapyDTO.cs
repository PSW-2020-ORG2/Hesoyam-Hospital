using Backend;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapter.DTOs
{
    public class TherapyDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime DateCreated { get; set; }
        public long PatientID { get; set; }
        public long DoctorID { get; set; }
        public string Comment { get; set; }
        public List<long> MedicineIDs { get; set; }

        public static Therapy TherapyDTOToTherapy(TherapyDTO therapyDTO)
        {
            Therapy therapy = new Therapy();
            therapy.TimeInterval = new TimeInterval(therapyDTO.StartTime, therapyDTO.EndTime);
            therapy.Comment = therapyDTO.Comment;
            Prescription prescription = new Prescription();
            prescription.DateCreated = therapyDTO.DateCreated;
            prescription.Patient = AppResources.getInstance().patientService.GetByID(therapyDTO.PatientID);
            prescription.Doctor = AppResources.getInstance().doctorService.GetByID(therapyDTO.DoctorID);
            prescription.Type = DocumentType.PRESCRIPTION;
            List<MedicalTherapy> medicalTherapies = BindMedicinesWithTherapies(therapyDTO.MedicineIDs);
            prescription.MedicalTherapies = medicalTherapies;
            prescription.Status = PrescriptionStatus.ACTIVE;
            therapy.Prescription = prescription;
            return therapy;
        }

        private static List<MedicalTherapy> BindMedicinesWithTherapies(List<long> medicineIDs)
        {
            List<MedicalTherapy> medicalTherapies = new List<MedicalTherapy>();
            MedicalTherapy t1 = new MedicalTherapy();
            MedicalTherapy t2 = new MedicalTherapy();
            t1.Medicine = AppResources.getInstance().medicineService.GetByID(1);
            t2.Medicine = AppResources.getInstance().medicineService.GetByID(2);
            Console.WriteLine("EQUALS?" + t1.Equals(t2));
            foreach (long id in medicineIDs)
            {
                MedicalTherapy therapy = new MedicalTherapy();
                therapy.Medicine = AppResources.getInstance().medicineService.GetByID(id);
                medicalTherapies.Add(therapy);
            }
            return medicalTherapies;
        }
    }
}
