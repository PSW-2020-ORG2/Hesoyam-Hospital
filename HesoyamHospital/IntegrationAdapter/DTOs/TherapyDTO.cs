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
            TimeInterval therapyTimeInterval = new TimeInterval(therapyDTO.StartTime, therapyDTO.EndTime);
            Patient patient = AppResources.getInstance().patientService.GetByID(therapyDTO.PatientID);
            Doctor doctor = AppResources.getInstance().doctorService.GetByID(therapyDTO.DoctorID);
            List<MedicalTherapy> medicalTherapies = BindMedicinesWithTherapies(therapyDTO.MedicineIDs);
            Prescription prescription = new Prescription(therapyDTO.DateCreated, patient, doctor, medicalTherapies);

            Therapy therapy = new Therapy(therapyTimeInterval, prescription, therapyDTO.Comment);

            return therapy;
        }

        private static List<MedicalTherapy> BindMedicinesWithTherapies(List<long> medicineIDs)
        {
            List<MedicalTherapy> medicalTherapies = new List<MedicalTherapy>();
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
