namespace Authentication.Model.MedicalRecordModel
{
    public class Allergy
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Allergy() { }

        public Allergy(long id)
        {
            Id = id;
            Name = "";
            
        }

        public Allergy(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            return obj is Allergy allergy && Id == allergy.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}