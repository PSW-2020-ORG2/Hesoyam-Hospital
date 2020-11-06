using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Dtos;

namespace WebApplication.Adapters
{
    public class FeedbackAdapter
    {
        public static Feedback FeedbackDtoToFeedback(FeedbackDto dto)
        {
            Feedback feedback = new Feedback();
            feedback.Id = dto.Id;
            feedback.User.UserName = dto.UserName;
            feedback.Comment = dto.Comment;
            feedback.Anonymous = dto.Anonymous;
            feedback.Public = dto.Public;
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
            return dto;
        }
    }
}
