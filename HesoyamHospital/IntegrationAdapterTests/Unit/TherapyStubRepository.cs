using Backend.Model.PatientModel;
using Backend.Repository.MySQLRepository.MedicalRepository;
using Backend.Util;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationAdapterTests.Unit
{
    public class TherapyStubRepository
    {
        public static TherapyRepository CreateRepository(TimeInterval interval)
        {
            var stubRepository = new Mock<TherapyRepository>();

            List<Therapy> therapies = new List<Therapy>();

            Medicine m1 = new Medicine(1); m1.Name = "LEK1"; m1.MedicineType = MedicineType.PILL;
            Medicine m2 = new Medicine(2); m2.Name = "LEK2"; m1.MedicineType = MedicineType.DROPS;
            Medicine m3 = new Medicine(3); m3.Name = "LEK3"; m1.MedicineType = MedicineType.PILL;

            MedicalTherapy mt1 = new MedicalTherapy(); mt1.Id = 1; mt1.Medicine = m1;
            MedicalTherapy mt2 = new MedicalTherapy(); mt2.Id = 2; mt2.Medicine = m2;
            MedicalTherapy mt3 = new MedicalTherapy(); mt3.Id = 3; mt3.Medicine = m3;

            List<MedicalTherapy> medicalTherapies1 = new List<MedicalTherapy>();
            medicalTherapies1.Add(mt1); medicalTherapies1.Add(mt2); medicalTherapies1.Add(mt3);
            Prescription p1 = new Prescription(1);
            p1.MedicalTherapies = medicalTherapies1;
            Therapy t1 = new Therapy(1);
            t1.Prescription = p1;
            t1.Prescription.DateCreated = new DateTime(2020, 10, 15);
            therapies.Add(t1);

            List<MedicalTherapy> medicalTherapies2 = new List<MedicalTherapy>();
            medicalTherapies2.Add(mt1); medicalTherapies2.Add(mt3);
            Prescription p2 = new Prescription(2);
            p2.MedicalTherapies = medicalTherapies2;
            Therapy t2 = new Therapy(2);
            t2.Prescription = p2;
            t2.Prescription.DateCreated = new DateTime(2020, 11, 7);
            therapies.Add(t2);

            List<Therapy> filtered = filterByTimeInterval(therapies, interval);

            stubRepository.Setup(m => m.GetTherapyByDatePrescribed(interval)).Returns(filtered);

            return stubRepository.Object;
        }

        private static List<Therapy> filterByTimeInterval(List<Therapy> therapies, TimeInterval interval)
        {
            List<Therapy> retVal = new List<Therapy>();
            foreach(Therapy t in therapies)
            {
                if (interval.IsDateTimeBetween(t.Prescription.DateCreated))
                {
                    retVal.Add(t);
                }
            }
            return retVal;
        }
    }
}
