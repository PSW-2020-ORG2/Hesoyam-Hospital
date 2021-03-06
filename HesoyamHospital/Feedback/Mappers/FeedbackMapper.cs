﻿using Feedbacks.Model;
using Feedbacks.DTOs;

namespace Feedbacks.Mappers
{
    public static class FeedbackMapper
    {
        public static NewFeedbackDTO FeedbackToNewFeedbackDTO(Feedback feedback)
        {
            return new NewFeedbackDTO(feedback.Comment, feedback.Anonymous, feedback.Public, feedback.PatientUsername);
        }

        public static Feedback NewFeedbackDTOToFeedback(NewFeedbackDTO dto)
        {
            return new Feedback(dto.Anonymous ? "Anonymous" : dto.Username, dto.Comment, dto.Anonymous, dto.Public);
        }

        public static Feedback FeedbackDtoToFeedback(FeedbackDTO dto)
        {
            Feedback feedback = new Feedback
            {
                Id = dto.Id
            };
            feedback.PatientUsername = dto.UserName;
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
                UserName = feedback.Anonymous ? "Anonymous" : feedback.PatientUsername,
                Comment = feedback.Comment,
                Anonymous = feedback.Anonymous,
                Public = feedback.Public,
                Published = feedback.Published
            };

            return dto;
        }
    }
}
