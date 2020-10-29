// File:    FeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 18:21:30
// Purpose: Definition of Class FeedbackRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class FeedbackRepository : CSVRepository<Feedback, long>, IFeedbackRepository, IEagerCSVRepository<Feedback, long>
    {
        private const string ENTITY_NAME = "Feedback";
        private IQuestionRepository _questionRepository;
        private IPatientRepository _patientRepository;
        private IDoctorRepository _doctorRepository;
        private IManagerRepository _managerRepository;
        private ISecretaryRepository _secretaryRepository;

        public FeedbackRepository(ICSVStream<Feedback> stream, ISequencer<long> sequencer, IQuestionRepository questionRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository, IManagerRepository managerRepository, ISecretaryRepository secretaryRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Feedback>())
        {
            _questionRepository = questionRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _managerRepository = managerRepository;
            _secretaryRepository = secretaryRepository;
        }

        public IEnumerable<Feedback> GetAllEager()
        {
            var feedbacks = GetAll();
            BindFeedbackWithUsers(feedbacks);
            BindFeedbackWithQuestions(feedbacks);

            return feedbacks;
        }

        private void BindFeedbackWithQuestions(IEnumerable<Feedback> feedbacks)
        {
            var questions = _questionRepository.GetAll();
            foreach(Feedback f in feedbacks)
            {
                Dictionary<Question, Rating> dict = new Dictionary<Question, Rating>();
                foreach(Question question in f.Rating.Keys)
                {
                    dict.Add(questions.SingleOrDefault(q => q.GetId() == question.GetId()), f.Rating[question]);
                }
                f.Rating = dict;
            }
        }

        private void BindFeedbackWithUsers(IEnumerable<Feedback> feedbacks)
        {
            IEnumerable<User> patients = _patientRepository.GetAll();
            IEnumerable<User> doctors = _doctorRepository.GetAll();
            IEnumerable<User> managers = _managerRepository.GetAll();
            IEnumerable<User> secretaries = _secretaryRepository.GetAll();
            IEnumerable<User> users = patients.Concat(doctors).Concat(managers).Concat(secretaries);

            feedbacks.ToList().ForEach(f => f.User = GetUserById(users, f.User));
        }

        public Feedback GetEager(long id)
            => GetAllEager().SingleOrDefault(feedback => feedback.GetId() == id);

        private User GetUserById(IEnumerable<User> users, User userId)
            => userId == null ? null : users.SingleOrDefault(user => user.GetId().Equals(userId.GetId()));
    }
}