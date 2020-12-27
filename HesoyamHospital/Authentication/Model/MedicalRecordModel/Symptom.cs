namespace Authentication.Model.MedicalRecordModel
{
    public class Symptom
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }

        public long GetId()
            => Id;

        public void SetId(long id)
            => Id = id;


        public Symptom(long id){
            Id = id;
        }

        public Symptom(long id, string name, string shortDescription)
        {
            Id = id;
            Name = name;
            ShortDescription = shortDescription;
        }

        public Symptom(string name, string shortDescription)
        {
            Name = name;
            ShortDescription = shortDescription;
        }

        public override bool Equals(object obj)
        {
            return obj is Symptom symptom && Id == symptom.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}