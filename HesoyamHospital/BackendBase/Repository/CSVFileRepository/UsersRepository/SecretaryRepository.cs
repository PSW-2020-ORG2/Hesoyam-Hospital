// File:    SecretaryRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:34
// Purpose: Definition of Class SecretaryRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.UsersRepository
{
    public class SecretaryRepository : CSVRepository<Secretary, UserID>, ISecretaryRepository, IEagerCSVRepository<Secretary, UserID>
    {
        private readonly ITimeTableRepository _timeTableRepository;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IUserRepository _userRepository;
        private const string ENTITY_NAME = "Secretary";
        private const string NOT_UNIQUE_ERROR = "Secretary username {0} is not unique!";

        public SecretaryRepository(ICSVStream<Secretary> stream, ISequencer<UserID> sequencer, ITimeTableRepository timeTableRepository, IHospitalRepository hospitalRepository, IUserRepository userRepository) : base(ENTITY_NAME, stream, sequencer, new SecretaryIdGeneratorStrategy())
        {
            _timeTableRepository = timeTableRepository;
            _hospitalRepository = hospitalRepository;
            _userRepository = userRepository;
        }

        public new Secretary Create(Secretary secretary)
        {
            if (IsUsernameUnique(secretary.UserName))
            {
                secretary.DateCreated = DateTime.Now;

                secretary = base.Create(secretary);
                _userRepository.AddUser(secretary);
                return secretary;
            }
            else
                throw new NotUniqueException(string.Format(NOT_UNIQUE_ERROR, secretary.UserName));
        }

        public new void Update(Secretary secretary)
        {
            _userRepository.Update(secretary);
            base.Update(secretary);
        }

        private bool IsUsernameUnique(string userName)
            => _userRepository.GetByUsername(userName) == null;

        public IEnumerable<Secretary> GetAllEager()
        {
            var secretaries = GetAll();
            Bind(secretaries);
            
            return secretaries;
        }

        public Secretary GetEager(UserID id)
        {
            var secretary = GetByID(id);
            var timetables = _timeTableRepository.GetAll();
            secretary.TimeTable = GetTimeTableById(secretary.TimeTable, timetables);
            var hospitals = _hospitalRepository.GetAll();
            secretary.Hospital = GetHospitalById(secretary.Hospital, hospitals);
            return secretary;
        }

        private Hospital GetHospitalById(Hospital hospitalId, IEnumerable<Hospital> hospitals)
            => hospitalId == null ? null : hospitals.SingleOrDefault(h => h.GetId() == hospitalId.GetId());

        private TimeTable GetTimeTableById(TimeTable timeTableId, IEnumerable<TimeTable> timetables)
            => timeTableId == null ? null : timetables.SingleOrDefault(t => t.GetId() == timeTableId.GetId());

        private void Bind(IEnumerable<Secretary> secretaries)
        {
            var timetables = _timeTableRepository.GetAll();
            BindSecretariesWithTimetables(secretaries, timetables);

            var hospitals = _hospitalRepository.GetAll();
            BindSecretariesWithHospitals(secretaries, hospitals);
        }

        private void BindSecretariesWithTimetables(IEnumerable<Secretary> secretaries, IEnumerable<TimeTable> timetables)
            => secretaries.ToList().ForEach(secretary => secretary.TimeTable = GetTimeTableById(secretary.TimeTable, timetables));

        private void BindSecretariesWithHospitals(IEnumerable<Secretary> secretaries, IEnumerable<Hospital> hospitals)
            => secretaries.ToList().ForEach(secretary => secretary.Hospital = GetHospitalById(secretary.Hospital, hospitals));
    }
}