using Authentication.Model.FeedbackModel;
using Feedbacks.Repository.Abstract;
using Feedbacks.Repository.SQLRepository.Base;

namespace Feedbacks.Repository
{
    public class FeedbackRepository : SQLRepository<Feedback, long>, IFeedbackRepository
    {
        public FeedbackRepository(ISQLStream<Feedback> stream) : base(stream)
        {
        }

    }
}
