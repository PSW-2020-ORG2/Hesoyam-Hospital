// File:    PatientService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class PatientService

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.UsersRepository;
using Backend.Repository.MySQLRepository.MedicalRepository;
using Backend.Model.PatientModel;
using Backend.Exceptions;
using Backend.Util;

namespace Backend.Service.UsersService
{
    public class PatientService : IService<Patient, long>
    {
        readonly PatientRepository _patientRepository;
        readonly DoctorRepository _doctorRepository;
        readonly MedicalRecordRepository _medicalRecordRepository;
        UserValidation _userValidation;

        public PatientService(PatientRepository patientRepository, MedicalRecordRepository medicalRecordRepository, DoctorRepository doctorRepository)
        {
            _patientRepository = patientRepository;
            _medicalRecordRepository = medicalRecordRepository;
            _doctorRepository = doctorRepository;
            _userValidation = new UserValidation();
        }

        public IEnumerable<Patient> GetPatientByDoctor(Doctor doctor)
            => _patientRepository.GetPatientByDoctor(doctor);

        public IEnumerable<Patient> GetAll()
            => _patientRepository.GetAllEager();

        public Patient GetByID(long id)
            => _patientRepository.GetByID(id);

        public Patient GetByUsername(string username)
            => _patientRepository.GetPatientByUsername(username);

        public Patient Create(Patient entity)
        {
            Validate(entity);
            Patient patient = _patientRepository.Create(entity);
            _medicalRecordRepository.Create(new MedicalRecord(patient));

            return patient;

        }

        public Patient Activate(long id)
        {
            Patient patient = _patientRepository.GetEager(id);
            if (patient == null) return null;
            patient.Active = true;
            _patientRepository.Update(patient);
            return patient;
        }

        public Patient ChangeSelectedDoctor(long doctorId, long patientId)
        {
            Patient patient = _patientRepository.GetEager(patientId);
            Doctor selectedDoctor = _doctorRepository.GetByID(doctorId);
            if (patient == null || selectedDoctor == null) return null;
            patient.SelectedDoctor = selectedDoctor;
            _patientRepository.Update(patient);
            return patient;
        }

        public void Delete(Patient entity)
            => _patientRepository.Delete(entity);

        public void Validate(Patient user)
            => _userValidation.Validate(user);

        public void Update(Patient entity)
        {
            Validate(entity);
            _patientRepository.Update(entity);
        }

        public bool IsUsernameUnique(string username)

             => _patientRepository.IsUsernameUnique(username);
        

        public UserValidation UserValidation { get => _userValidation; set => _userValidation = value; }
    }
}