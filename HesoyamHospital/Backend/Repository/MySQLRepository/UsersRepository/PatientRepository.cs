// File:    PatientRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:33
// Purpose: Definition of Class PatientRepository

using Backend.Model.UserModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.UsersRepository
{
    public class PatientRepository : MySQLRepository<Patient, long>, IPatientRepository, IEagerRepository<Patient, long>
    {
        private const string ENTITY_NAME = "Patient";
        private const string NOT_UNIQUE_ERROR = "Patient username {0} is not unique!";
        private readonly IUserRepository _userRepository;
        
        public PatientRepository(IMySQLStream<Patient> stream, ISequencer<long> sequencer, IUserRepository userRepository) : base(ENTITY_NAME, stream, sequencer, new PatientIdGeneratorStrategy())
        {
            _userRepository = userRepository;
        }

        public new Patient Create(Patient patient)
        {
            if (IsUsernameUnique(patient.UserName))
            {
                patient.DateCreated = DateTime.Now;
                patient = base.Create(patient);
                _userRepository.AddUser(patient);
                return patient;
            }
            else
            {
                throw new NotUniqueException(string.Format(NOT_UNIQUE_ERROR, patient.UserName));
            }
        }

        private bool IsUsernameUnique(string userName)
            => _userRepository.GetByUsername(userName) == null;

        public IEnumerable<Patient> GetPatientByDoctor(Doctor doctor)
            => GetAll().Where(patient => IsDoctorIdEqualsDoctor(patient.SelectedDoctor, doctor));

        public Patient GetPatientByUsername(string username)
            => GetAll().SingleOrDefault(patient => patient.UserName == username);

        private bool IsDoctorIdEqualsDoctor(Doctor doctorId, Doctor doctor)
            => doctorId == null ? false : doctorId.GetId().Equals(doctor.GetId());

        
    }
}