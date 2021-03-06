using System.Collections.Generic;

namespace Authentication.Model
{
    public class MedicalRecord
    {
        public long Id { get; set; }
        public BloodType PatientBloodType { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual List<Allergy> Allergy { get; set; }

        public MedicalRecord(long id)
        {
            Id = id;
        }

        public MedicalRecord(Patient patient)
        {
            Patient = patient;
            PatientBloodType = BloodType.NOT_TESTED;
            Allergy = new List<Allergy>();
        }

        public MedicalRecord(Patient patient, BloodType bloodType)
        {
            Patient = patient;
            PatientBloodType = bloodType;
            Allergy = new List<Allergy>();
        }

        public MedicalRecord(Patient patient, BloodType bloodType, List<Allergy> patientAllergies)
        {
            Patient = patient;
            PatientBloodType = bloodType;
            Allergy = patientAllergies;
        }


        public MedicalRecord(long id, Patient patient, BloodType bloodType, List<Allergy> patientAllergies)
        {
            Id = id;
            Patient = patient;
            PatientBloodType = bloodType;
            Allergy = patientAllergies;
        }

        public long GetId()
            => Id;

        public void SetId(long id)
            => Id = id;

        public override bool Equals(object obj)
        {
            return obj is MedicalRecord record && Id == record.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
      
        public string BloodTypeToString(BloodType bt) 
        {
            return bt switch
            {
                BloodType.A_POSITIVE => "A+",
                BloodType.A_NEGATIVE => "A-",
                BloodType.AB_POSITIVE => "AB+",
                BloodType.AB_NEGATIVE => "AB-",
                BloodType.B_POSITIVE => "B+",
                BloodType.B_NEGATIVE => "B-",
                BloodType.O_POSITIVE => "0+",
                BloodType.O_NEGATIVE => "0-",
                BloodType.NOT_TESTED => "Not tested",
                _ => "Not tested",
            };
        }

        public List<string> AllergiesListToString(List<Allergy> allergies)
        {
            List<string> retVal = new List<string>();
            foreach (Allergy a in allergies) {
                retVal.Add(a.Name);
            }
            if (retVal.Count == 0) {
                retVal.Add("No allergies");
            }
            return retVal;
        }
    }
}