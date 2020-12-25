using Backend.Model.UserModel;
using System.Collections.Generic;

namespace Feedbacks.Service.Abstract
{
    public interface IFeedbackService : IService<Feedback, long>
    {
        public Feedback GetByUser(User user);
        public void Publish(long id);
        public List<Feedback> GetAllUnpublished();
        public List<Feedback> GetAllPublished();
    }
}
