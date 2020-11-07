// File:    FeedbackService.cs
// Author:  nikola
// Created: 6. maj 2020 18:46:57
// Purpose: Definition of Class FeedbackService

using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Exceptions;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Repository.MySQLRepository.MiscRepository;

namespace Backend.Service.MiscService
{
    public class FeedbackService : IService<Feedback, long>
    {
        private FeedbackRepository _feedbackRepository;
        private QuestionRepository _questionRepository;

        public FeedbackService(FeedbackRepository feedbackRepository, QuestionRepository questionRepository)
        {
            _feedbackRepository = feedbackRepository;
            _questionRepository = questionRepository;
        }

        public Feedback Create(Feedback entity)
        {
            Validate(entity);
            return _feedbackRepository.Create(entity);
        }

        public void Delete(Feedback entity)
            => _feedbackRepository.Delete(entity);

        public IEnumerable<Question> GetQuestions()
            => _questionRepository.GetAll();

        public Feedback GetByUser(User user)
            => _feedbackRepository.GetAllEager().FirstOrDefault(f => f.User.Equals(user));

        public IEnumerable<Feedback> GetAll()
            => _feedbackRepository.GetAllEager();

        public Feedback GetByID(long id)
            => _feedbackRepository.GetEager(id);

        public void Update(Feedback entity)
        {
            Validate(entity);
            _feedbackRepository.Update(entity);
        }

        public void Publish(long id)
        {
           Feedback feedback= _feedbackRepository.GetEager(id);
            if (feedback != null)
            {
                feedback.Published = true;
                _feedbackRepository.Update(feedback);
            }
        }

        public IEnumerable<Feedback> GetAllUnpublished()
        {
            IEnumerable<Feedback> result = new List<Feedback>();
            IEnumerable<Feedback> feedbacks = _feedbackRepository.GetAllEager();
            foreach(Feedback feedback in feedbacks)
            {
                if (feedback.Published == false)
                {
                    result.Append(feedback);
                }
            }
            return result;
        }

        public void Validate(Feedback entity)
        {
            if (entity.User == null)
            {
                throw new FeedbackServiceException("User is null!");
            }

            if (entity.Rating == null)
            {
                throw new FeedbackServiceException("Feedback is empty!");
            }
        }
    }
}