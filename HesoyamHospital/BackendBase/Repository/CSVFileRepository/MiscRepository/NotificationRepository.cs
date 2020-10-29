// File:    NotificationRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:31:13
// Purpose: Definition of Class NotificationRepository

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

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class NotificationRepository : CSVRepository<Notification, long>, INotificationRepository, IEagerCSVRepository<Notification, long>
    {
        private const string ENTITY_NAME = "Notification";
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly ISecretaryRepository _secretaryRepository;
        public NotificationRepository(ICSVStream<Notification> stream, ISequencer<long> sequencer, IPatientRepository patientRepository, IDoctorRepository doctorRepository, IManagerRepository managerRepository, ISecretaryRepository secretaryRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Notification>())
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _managerRepository = managerRepository;
            _secretaryRepository = secretaryRepository;
        }

        public new Notification Create(Notification notification)
        {
            notification.Date = DateTime.Now;
            return base.Create(notification);
        }

        public IEnumerable<Notification> GetAllEager()
        {
            var notifications = GetAll();
            BindNotificationsWithUser(notifications);
            return notifications;
        }

        private void BindNotificationsWithUser(IEnumerable<Notification> notifications)
        {
            IEnumerable<User> patients = _patientRepository.GetAll();
            IEnumerable<User> doctors = _doctorRepository.GetAll();
            IEnumerable<User> managers = _managerRepository.GetAll();
            IEnumerable<User> secretaries = _secretaryRepository.GetAll();
            IEnumerable<User> users = patients.Concat(doctors).Concat(managers).Concat(secretaries);

            notifications.ToList().ForEach(n => n.Recipient = GetUserById(users, n.Recipient));
        }

        public Notification GetEager(long id)
            => GetAllEager().ToList().SingleOrDefault(notification => notification.GetId() == id);

        public IEnumerable<Notification> GetNotificationByUser(User user)
            => GetAll().ToList().Where(notification => notification.Recipient == null ? false : notification.Recipient.GetId().Equals(user.GetId()));

        private User GetUserById(IEnumerable<User> users, User userId)
            => userId == null ? null : users.SingleOrDefault(user => user.GetId().Equals(userId.GetId()));
    }
}