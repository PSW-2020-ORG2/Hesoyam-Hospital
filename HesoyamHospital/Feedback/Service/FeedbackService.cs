using Feedbacks.Model;
using Feedbacks.Repository;
using Feedbacks.Service.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Feedbacks.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly FeedbackRepository _feedbackRepository;

        public FeedbackService(FeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public Feedback Create(Feedback entity)
            => _feedbackRepository.Create(entity);

        public void Delete(Feedback entity)
            => _feedbackRepository.Delete(entity);

        public Feedback GetByUsername(string username)
            => _feedbackRepository.GetAll().FirstOrDefault(f => f.PatientUsername.Equals(username));

        public IEnumerable<Feedback> GetAll()
            => _feedbackRepository.GetAll();

        public Feedback GetByID(long id)
            => _feedbackRepository.GetByID(id);

        public void Update(Feedback entity)
            => _feedbackRepository.Update(entity);

        public void Publish(long id)
        {
            Feedback feedback = _feedbackRepository.GetByID(id);
            if (feedback == null) return;

            feedback.Published = true;
            _feedbackRepository.Update(feedback);
        }

        public List<Feedback> GetAllUnpublished()
        {
            List<Feedback> result = new List<Feedback>();
            List<Feedback> feedbacks = _feedbackRepository.GetAll().ToList();

            foreach (Feedback feedback in feedbacks)
            {
                if (!feedback.Published)
                {
                    result.Add(feedback);
                }
            }
            return result;
        }

        public List<Feedback> GetAllPublished()
        {
            List<Feedback> result = new List<Feedback>();
            List<Feedback> feedbacks = _feedbackRepository.GetAll().ToList();

            foreach (Feedback feedback in feedbacks)
            {
                if (feedback.Published)
                {
                    result.Add(feedback);
                }
            }
            return result;
        }
    }
}
