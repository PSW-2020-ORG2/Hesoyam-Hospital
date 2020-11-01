// File:    MessageRepository.cs
// Author:  Geri
// Created: 24. maj 2020 15:56:19
// Purpose: Definition of Class MessageRepository

using Backend.Model.UserModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.MySQLRepository.UsersRepository;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Backend.Repository.MySQLRepository.MiscRepository
{
    public class MessageRepository : MySQLRepository<Message, long>, IMessageRepository, IEagerRepository<Message, long>
    {
        private const string ENTITY_NAME = "Message";
        private IPatientRepository _patientRepository;
        private IDoctorRepository _doctorRepository;
        private IManagerRepository _managerRepository;
        private ISecretaryRepository _secretaryRepository;

        public MessageRepository(IMySQLStream<Message> stream, ISequencer<long> sequencer, IPatientRepository patientRepository, IDoctorRepository doctorRepository, IManagerRepository managerRepository, ISecretaryRepository secretaryRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Message>())
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _managerRepository = managerRepository;
            _secretaryRepository = secretaryRepository;
        }

        public new Message Create(Message message)
        {
            message.Date = DateTime.Now;
            return base.Create(message);
        }

        public void BindMessagesWithUsers(IEnumerable<Message> messages)
        {
            IEnumerable<User> patients = _patientRepository.GetAll();
            IEnumerable<User> doctors = _doctorRepository.GetAll();
            IEnumerable<User> managers = _managerRepository.GetAll();
            IEnumerable<User> secretaries = _secretaryRepository.GetAll();
            IEnumerable<User> users = patients.Concat(doctors).Concat(managers).Concat(secretaries);

            messages.ToList().ForEach(m => { m.Recipient = GetUserById(users, m.Recipient); m.Sender = GetUserById(users, m.Sender); });
        }

        private User GetUserById(IEnumerable<User> users, User userId)
            => userId == null ? null : users.SingleOrDefault(user => user.GetId().Equals(userId.GetId()));

        public IEnumerable<Message> GetSent(User user)
            => GetAllEager().ToList().Where(message => IsUserIdsEqual(message.Sender, user));

        private bool IsUserIdsEqual(User senderId, User selectedUser)
            => senderId == null ? false : selectedUser.GetId().Equals(senderId.GetId());

        public IEnumerable<Message> GetReceived(User user)
            => GetAllEager().ToList().Where(message => IsUserIdsEqual(message.Recipient, user));

        public Message GetEager(long id)
            => GetAllEager().ToList().SingleOrDefault(message => message.GetId() == id);

        public IEnumerable<Message> GetAllEager()
        {
            IEnumerable<Message> messages = GetAll();
            BindMessagesWithUsers(messages);
            return messages;
        }
    }
}