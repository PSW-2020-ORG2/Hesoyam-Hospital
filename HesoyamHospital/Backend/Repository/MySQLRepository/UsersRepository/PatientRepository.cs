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
    public class PatientRepository : MySQLRepository<Patient, UserID>, IPatientRepository, IEagerRepository<Patient, UserID>
    {
        private const string ENTITY_NAME = "Patient";
        private const string NOT_UNIQUE_ERROR = "Patient username {0} is not unique!";
        private readonly IEagerRepository<Doctor, UserID> _doctorRepository;
        private readonly IUserRepository _userRepository;
        public PatientRepository(IMySQLStream<Patient> stream, ISequencer<UserID> sequencer, IEagerRepository<Doctor, UserID> doctorRepository, IUserRepository userRepository) : base(ENTITY_NAME, stream, sequencer, new PatientIdGeneratorStrategy())
        {
            _doctorRepository = doctorRepository;
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

        public new void Update(Patient patient)
        {
            _userRepository.Update(patient);
            base.Update(patient);
        }

        private bool IsUsernameUnique(string userName)
            => _userRepository.GetByUsername(userName) == null;

        public IEnumerable<Patient> GetAllEager()
        {
            var patients = GetAll();
            Bind(patients);
            return patients;
        }

        private void Bind(IEnumerable<Patient> patients)
        {
            var doctors = _doctorRepository.GetAllEager();
            patients.ToList().ForEach(patient => patient.SelectedDoctor = GetDoctorByID(patient.SelectedDoctor, doctors));
        }

        public Patient GetEager(UserID id)
        {
            var patient = GetByID(id);
            var doctors = _doctorRepository.GetAllEager();
            patient.SelectedDoctor = GetDoctorByID(patient.SelectedDoctor, doctors);
            return patient;
        }

        private Doctor GetDoctorByID(Doctor doctorId, IEnumerable<Doctor> doctors)
            => doctorId == null ? null : doctors.SingleOrDefault(d => d.GetId().Equals(doctorId.GetId()));

        public IEnumerable<Patient> GetPatientByDoctor(Doctor doctor)
            => GetAll().Where(patient => IsDoctorIdEqualsDoctor(patient.SelectedDoctor, doctor));
        

        public IEnumerable<Patient> GetPatientByType(PatientType patientType)
        {
            var doctors = _doctorRepository.GetAllEager();
            var patients = GetAll().Where(patient => patient.PatientType == patientType);

            patients.ToList().ForEach(patient => patient.SelectedDoctor = GetDoctorByID(patient.SelectedDoctor, doctors));

            return patients;
        }

        private bool IsDoctorIdEqualsDoctor(Doctor doctorId, Doctor doctor)
            => doctorId == null ? false : doctorId.GetId().Equals(doctor.GetId());

        
    }
}