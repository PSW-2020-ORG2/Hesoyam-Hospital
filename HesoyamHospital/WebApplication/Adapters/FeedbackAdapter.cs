﻿using Backend;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTOs;

namespace WebApplication.Adapters
{
    public class FeedbackAdapter
    {
        public static NewFeedbackDTO feedbackToNewFeedbackDTO(Feedback feedback)
        {
            return new NewFeedbackDTO(feedback.Comment, feedback.Anonymous, feedback.Public);
        }

        public static Feedback newFeedbackDTOToFeedback (NewFeedbackDTO dto)
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
            FeedbackDto dto = new FeedbackDto();
            dto.Id = feedback.Id;
            dto.UserName = feedback.User.UserName;
            dto.Comment = feedback.Comment;
            dto.Anonymous = feedback.Anonymous;
            dto.Public = feedback.Public;
            dto.Published = feedback.Published;
            return dto;
        }
    }
}
