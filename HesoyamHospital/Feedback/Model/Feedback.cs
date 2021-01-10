namespace Feedbacks.Model
{
    public class Feedback
    {
        public long Id {get; set;}
        public string PatientUsername { get; set; }
        public bool Published { get; set; }
        public bool Anonymous { get; set; }
        public bool Public { get; set; }
        public string Comment { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public Feedback(string patientUsername, string comment)
        {
            PatientUsername = patientUsername;
            Comment = comment;
        }

        public Feedback(long id, string patientUsername, string comment)
        {
            Id = id;
            PatientUsername = patientUsername;
            Comment = comment;
        }

        public Feedback(long id)
        {
            Id = id;
        }

        public Feedback(string _patientUsername, string _comment, bool _anonymous, bool _public)
        {
            PatientUsername = _patientUsername;
            Comment = _comment;
            Anonymous = _anonymous;
            Public = _public;
        }

        public Feedback() { }
        
        public override bool Equals(object obj)
        {
            return obj is Feedback feedback && Id == feedback.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}