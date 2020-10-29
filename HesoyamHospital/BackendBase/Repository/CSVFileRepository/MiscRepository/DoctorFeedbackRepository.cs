// File:    DoctorFeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:52:51
// Purpose: Definition of Class DoctorFeedbackRepository

using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class DoctorFeedbackRepository : CSVRepository<DoctorFeedback, long>, IDoctorFeedbackRepository, IEagerCSVRepository<DoctorFeedback, long>
    {
        private const string ENTITY_NAME = "DoctorFeedback";
        private IQuestionRepository _questionRepository;
        private IPatientRepository _patientRepository;
        private IDoctorRepository _doctorRepository;
        //private IManagerRepository _managerRepository;
        //private ISecretaryRepository _secretaryRepository;

        public DoctorFeedbackRepository(ICSVStream<DoctorFeedback> stream, ISequencer<long> sequencer, IQuestionRepository questionRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<DoctorFeedback>())
        {
            _questionRepository = questionRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<DoctorFeedback> GetByDoctor(Doctor doctor)
            => GetAllEager().ToList().Where(df => IsUserIdsEqual(df.Doctor, doctor));

        private bool IsUserIdsEqual(User userId, User selectedUser)
            => userId == null ? false : userId.GetId().Equals(selectedUser.GetId());

        public DoctorFeedback GetByPatientDoctor(Patient patient, Doctor doctor)
            => GetAllEager().ToList().SingleOrDefault(df => IsUserIdsEqual(df.Doctor, doctor) && IsUserIdsEqual(df.User, patient));

        public DoctorFeedback GetEager(long id)
            => GetAllEager().SingleOrDefault(df => df.GetId() == id);

        public IEnumerable<DoctorFeedback> GetAllEager()
        {
            IEnumerable<DoctorFeedback> feedbacks = GetAll();

            BindWithDoctors(feedbacks);
            BindWithPatients(feedbacks);
            BindWithQuestions(feedbacks);
            return feedbacks;
        }

        private void BindWithQuestions(IEnumerable<DoctorFeedback> feedbacks)
        {
            var questions = _questionRepository.GetAll();
            foreach (DoctorFeedback f in feedbacks)
            {
                Dictionary<Question, Rating> dict = new Dictionary<Question, Rating>();
                foreach (Question question in f.Rating.Keys)
                {
                    dict.Add(questions.SingleOrDefault(q => q.GetId() == question.GetId()), f.Rating[question]);
                }
                f.Rating = dict;
            }
        }

        private void BindWithPatients(IEnumerable<DoctorFeedback> feedbacks)
        {
            var patients = _patientRepository.GetAll();

            feedbacks.ToList().ForEach(f => f.User = GetPatientById(patients, f.User));
        }

        private User GetPatientById(IEnumerable<Patient> patients, User patientId)
            => patientId == null ? null : patients.SingleOrDefault(patient => patient.GetId().Equals(patientId.GetId()));


        private void BindWithDoctors(IEnumerable<DoctorFeedback> feedbacks)
        {
            var doctors = _doctorRepository.GetAll();

            feedbacks.ToList().ForEach(f => f.Doctor = GetDoctorById(doctors, f.Doctor));
        }

        private Doctor GetDoctorById(IEnumerable<Doctor> doctors, Doctor doctorId)
            => doctorId == null ? null : doctors.SingleOrDefault(d => d.GetId().Equals(doctorId.GetId()));
    }
}