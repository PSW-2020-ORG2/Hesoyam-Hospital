﻿using Backend;
using Backend.Model.UserModel;
 using WebApplication.DTOs;

namespace WebApplication.Adapters
{
    public class FeedbackAdapter
    {
        public static NewFeedbackDTO FeedbackToNewFeedbackDTO(Feedback feedback)
        {
            return new NewFeedbackDTO(feedback.Comment, feedback.Anonymous, feedback.Public);
        }

        public static Feedback NewFeedbackDTOToFeedback(NewFeedbackDTO dto)
        {
            return new Feedback(AppResources.getInstance().userService.GetByID(500), dto.Comment, dto.Anonymous, dto.Public);
        }

        public static Feedback FeedbackDtoToFeedback(FeedbackDto dto)
        {
            Feedback feedback = new Feedback();

            feedback.Id = dto.Id;
            feedback.User.UserName = dto.UserName;
            feedback.Comment = dto.Comment;
            feedback.Anonymous = dto.Anonymous;
            feedback.Public = dto.Public;
            feedback.Published = dto.Published;

            return feedback;
               
        }
        public static FeedbackDto FeedbackToFeedbackDto(Feedback feedback)
        {
            FeedbackDto dto = new FeedbackDto
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
