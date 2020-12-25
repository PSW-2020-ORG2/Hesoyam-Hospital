﻿using Authentication.Repository;
using Authentication.Service.Abstract;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using System.Collections.Generic;

namespace Authentication.Service
{
    public class PatientService : IPatientService
    {
        readonly PatientRepository _patientRepository;
        readonly MedicalRecordRepository _medicalRecordRepository;

        public PatientService(PatientRepository patientRepository, MedicalRecordRepository medicalRecordRepository)
        {
            _patientRepository = patientRepository;
            _medicalRecordRepository = medicalRecordRepository;
        }

        public IEnumerable<Patient> GetAll()
            => _patientRepository.GetAll();

        public Patient GetByID(long id)
            => _patientRepository.GetByID(id);

        public Patient GetByUsername(string username)
            => _patientRepository.GetPatientByUsername(username);

        public Patient Create(Patient entity)
        {
            Patient patient = _patientRepository.Create(entity);
            _medicalRecordRepository.Create(new MedicalRecord(patient));
            return patient;
        }

        public void Delete(Patient entity)
            => _patientRepository.Delete(entity);

        public void Update(Patient entity)
            => _patientRepository.Update(entity);

        public Patient Activate(long id)
        {
            Patient patient = _patientRepository.GetByID(id);
            if (patient == null) return null;
            patient.Active = true;
            _patientRepository.Update(patient);
            return patient;
        }
    }
}