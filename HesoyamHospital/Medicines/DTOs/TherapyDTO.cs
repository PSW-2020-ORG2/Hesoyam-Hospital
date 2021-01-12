using Medicines.Model;
using Medicines.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.DTOs
{
    public class TherapyDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime DateCreated { get; set; }
        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public string Comment { get; set; }
        public List<long> MedicineIds { get; set; }

        public static Therapy TherapyDTOToTherapy(TherapyDTO therapyDTO, List<Medicine> medicines)
        {
            TimeInterval therapyTimeInterval = new TimeInterval(therapyDTO.StartTime, therapyDTO.EndTime);
            List<MedicalTherapy> medicalTherapies = BindMedicinesWithTherapies(medicines);
            Prescription prescription = new Prescription(therapyDTO.DateCreated, therapyDTO.PatientId, therapyDTO.DoctorId, medicalTherapies);

            Therapy therapy = new Therapy(therapyTimeInterval, prescription, therapyDTO.Comment);

            return therapy;
        }

        private static List<MedicalTherapy> BindMedicinesWithTherapies(List<Medicine> medicines)
        {
            List<MedicalTherapy> medicalTherapies = new List<MedicalTherapy>();
            foreach (Medicine medicine in medicines)
            {
                MedicalTherapy therapy = new MedicalTherapy();
                therapy.Medicine = medicine;
                medicalTherapies.Add(therapy);
            }
            return medicalTherapies;
        }
    }
}
