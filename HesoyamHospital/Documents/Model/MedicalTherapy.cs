using Documents.Util;

namespace Documents.Model
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

        public bool ContainsMedicineWithName(string name)
            => Medicine.Name.ToLower().Contains(name.ToLower());

        public bool MeetsMedicineNameCriteria(TextFilter filter)
        {
            if (filter.Filter == TextmatchFilter.EQUAL && Medicine.Name.ToLower().Equals(filter.Text.ToLower())) return true;
            if (filter.Filter == TextmatchFilter.CONTAINS && Medicine.Name.ToLower().Contains(filter.Text.ToLower())) return true;
            return false;
        }
    }
}
