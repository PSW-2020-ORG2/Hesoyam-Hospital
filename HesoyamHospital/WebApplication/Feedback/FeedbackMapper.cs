using Backend;

namespace WebApplication.Feedback
{
    public class FeedbackMapper
    {
        public static NewFeedbackDTO FeedbackToNewFeedbackDTO(Backend.Model.UserModel.Feedback feedback)
        {
            return new NewFeedbackDTO(feedback.Comment, feedback.Anonymous, feedback.Public);
        }

        public static Backend.Model.UserModel.Feedback NewFeedbackDTOToFeedback(NewFeedbackDTO dto)
        {
            return new Backend.Model.UserModel.Feedback(AppResources.getInstance().userService.GetByID(500), dto.Comment, dto.Anonymous, dto.Public);
        }

        public static Backend.Model.UserModel.Feedback FeedbackDtoToFeedback(FeedbackDTO dto)
        {
            Backend.Model.UserModel.Feedback feedback = new Backend.Model.UserModel.Feedback();

            feedback.Id = dto.Id;
            feedback.User.UserName = dto.UserName;
            feedback.Comment = dto.Comment;
            feedback.Anonymous = dto.Anonymous;
            feedback.Public = dto.Public;
            feedback.Published = dto.Published;

            return feedback;

        }
        public static FeedbackDTO FeedbackToFeedbackDto(Backend.Model.UserModel.Feedback feedback)
        {
            FeedbackDTO dto = new FeedbackDTO
            {
                Id = feedback.Id,
                UserName = feedback.Anonymous ? "Anonymous" : feedback.User.UserName,
                Comment = feedback.Comment,
                Anonymous = feedback.Anonymous,
                Public = feedback.Public,
                Published = feedback.Published
            };

            return dto;
        }
    }
}
