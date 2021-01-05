namespace Feedbacks.DTOs
{
    public class NewFeedbackDTO
    {
        public string Comment { get; set; }
        public bool Anonymous { get; set; }
        public bool Public { get; set; }
        public string Username { get; set; }

        public NewFeedbackDTO() { }

        public NewFeedbackDTO(string _comment, bool _anonymous, bool _public, string _username)
        {
            Comment = _comment;
            Anonymous = _anonymous;
            Public = _public;
            Username = _username;
        }
    }
}
