namespace Documents.Model
{
    public class Diagnosis
    {
        public long Id { get; set; }
        public string DiagnosisCode { get; set; }
        public string DiagnosisName { get; set; }


        public Diagnosis(long id)
        {
            Id = id;
        }

        public Diagnosis(long id, string diagnosisName, string diagnosisCode)
        {
            Id = id;
            DiagnosisName = diagnosisName;
            DiagnosisCode = diagnosisCode;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            return obj is Diagnosis diagnosis && Id == diagnosis.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}