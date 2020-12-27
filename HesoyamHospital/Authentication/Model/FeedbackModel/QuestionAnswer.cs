namespace Authentication.Model.FeedbackModel
{
    public class QuestionAnswer
    {
        public long Id { get; set; }
        public virtual Question Question { get; set; }
        public virtual Rating Rating { get; set; }

        public QuestionAnswer() { }
        public QuestionAnswer(Question question, Rating rating)
        {
            Question = question;
            Rating = rating;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            QuestionAnswer qa = obj as QuestionAnswer;
            return Id == qa.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}
