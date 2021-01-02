using Feedbacks.Model;
using System.Collections.Generic;

namespace Feedbacks.Service.Abstract
{
    public interface IFeedbackService : IService<Feedback, long>
    {
        public Feedback GetByUsername(string username);
        public void Publish(long id);
        public List<Feedback> GetAllUnpublished();
        public List<Feedback> GetAllPublished();
    }
}
