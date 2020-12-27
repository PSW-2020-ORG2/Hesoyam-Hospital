using System.Collections.Generic;

namespace Authentication.Model.MedicalRecordModel
{
    public class TherapyDose
    {
        public long Id { get; set; }
        public virtual List<SingleTherapyDose> Dosage { get; set; }

        public TherapyDose()
        {
        }

        public TherapyDose(List<SingleTherapyDose> dosage)
        {
            Dosage = dosage;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}