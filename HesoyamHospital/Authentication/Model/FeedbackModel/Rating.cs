namespace Authentication.Model.FeedbackModel
{
    public class Rating
    {
        public long Id { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }

        public Rating(string comment, int stars)
        {
            Comment = comment;
            Stars = stars;
        }

        public Rating() { }
    }
}