using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.MiscService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller.MiscController
{
    public class FeedbackController : IController<Feedback, long>
    {
        private FeedbackService _feedbackService;

        public FeedbackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public Feedback Create(Feedback entity)
            => _feedbackService.Create(entity);

        public void Delete(Feedback entity)
            => _feedbackService.Delete(entity);

        public IEnumerable<Feedback> GetAll()
            => _feedbackService.GetAll();

        public Feedback GetByID(long id)
            => _feedbackService.GetByID(id);

        public void Update(Feedback entity)
            => _feedbackService.Update(entity);

        public IEnumerable<Question> GetQuestions()
            => _feedbackService.GetQuestions();

        public Feedback GetByUser(User user)
            => _feedbackService.GetByUser(user);
    }
}
