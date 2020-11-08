using Backend;
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
    }
}
