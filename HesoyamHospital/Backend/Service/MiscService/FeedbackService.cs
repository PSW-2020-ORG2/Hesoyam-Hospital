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
using Backend.Repository.MySQLRepository.UsersRepository;

namespace Backend.Service.MiscService
{
    public class FeedbackService : IService<Feedback, long>
    {
        private FeedbackRepository _feedbackRepository;
        private QuestionRepository _questionRepository;
        private UserRepository _userRepository;

        public FeedbackService(FeedbackRepository feedbackRepository, QuestionRepository questionRepository, UserRepository userRepository)
        {
            _feedbackRepository = feedbackRepository;
            _questionRepository = questionRepository;
            _userRepository = userRepository;
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

        public List<Feedback> GetAllUnpublished()
        {
            List<Feedback> result = new List<Feedback>();
            List<Feedback> feedbacks = _feedbackRepository.GetAllEager().ToList();

            foreach (Feedback feedback in feedbacks)
            {
                long userID = feedback.UserId;
                User user = _userRepository.GetByID(userID);
                feedback.User = user;
            }

            foreach (Feedback feedback in feedbacks)
            {
                if (feedback.Published == false)
                {
                    result.Add(feedback);
                }
            }

            return result;
        }

        public List<Feedback> GetAllPublished()
        {
            List<Feedback> result = new List<Feedback>();
            List<Feedback> feedbacks = _feedbackRepository.GetAllEager().ToList();

            foreach (Feedback feedback in feedbacks)
            {
                long userID = feedback.UserId;
                User user = _userRepository.GetByID(userID);
                feedback.User = user;
            }

            foreach (Feedback feedback in feedbacks)
            {
                if (feedback.Published == true)
                {
                    result.Add(feedback);
                }
            }

            return result;
        }

        public void Validate(Feedback entity)
        {
            //if (entity.User == null)
            //{
            //    throw new FeedbackServiceException("User is null!");
            //}

            //if (entity.Rating == null)
            //{
            //    throw new FeedbackServiceException("Feedback is empty!");
            //}
        }
    }
}