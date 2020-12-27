﻿using Authentication.Model.Util;

namespace Authentication.Model.MedicalRecordModel
{
    public class MedicalTherapy
    {
        public long Id { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual TherapyDose Dose { get; set; }

        public MedicalTherapy() { }

        public MedicalTherapy(Medicine medicine, TherapyDose therapyDose)
        {
            Medicine = medicine;
            Dose = therapyDose;
        }

        public override bool Equals(object obj)
        {
            return obj is MedicalTherapy mt && Id == mt.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public bool containsMedicineWithName(string name)
            => Medicine.Name.ToLower().Contains(name.ToLower());

        public bool meetsMedicineNameCriteria(TextFilter filter)
        {
            if (filter.Filter == TextmatchFilter.EQUAL && Medicine.Name.ToLower().Equals(filter.Text.ToLower())) return true;
            if (filter.Filter == TextmatchFilter.CONTAINS && Medicine.Name.ToLower().Contains(filter.Text.ToLower())) return true;
            return false;
        }
    }
}
