using Backend.Model.UserModel;
using Feedbacks.DTOs;
using Feedbacks.Repository;
using Feedbacks.Repository.SQLRepository.Base;
using Feedbacks.Service;
using Feedbacks.Service.Abstract;

namespace Feedbacks.Mappers
{
    public class FeedbackMapper
    {
        private static readonly IPatientService _patientService = new PatientService(new PatientRepository(new SQLStream<Patient>()));

        public static NewFeedbackDTO FeedbackToNewFeedbackDTO(Feedback feedback)
        {
            return new NewFeedbackDTO(feedback.Comment, feedback.Anonymous, feedback.Public);
        }

        public static Feedback NewFeedbackDTOToFeedback(NewFeedbackDTO dto)
        {
            return new Feedback(_patientService.GetByID(500), dto.Comment, dto.Anonymous, dto.Public);
        }

        public static Feedback FeedbackDtoToFeedback(FeedbackDTO dto)
        {
            Feedback feedback = new Feedback
            {
                Id = dto.Id
            };
            feedback.User.UserName = dto.UserName;
            feedback.Comment = dto.Comment;
            feedback.Anonymous = dto.Anonymous;
            feedback.Public = dto.Public;
            feedback.Published = dto.Published;

            return feedback;

        }
        public static FeedbackDTO FeedbackToFeedbackDto(Feedback feedback)
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
