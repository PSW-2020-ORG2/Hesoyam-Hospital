using Feedbacks.DTOs;

namespace Feedbacks.Validation
{
    public static class FeedbackValidation
    {
        public static bool IsNewFeedbackValid(NewFeedbackDTO feedback)
            => feedback != null && feedback.Comment != null;
    }
}
