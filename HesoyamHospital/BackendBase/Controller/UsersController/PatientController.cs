// File:    PatientController.cs
// Author:  nikola
// Created: 22. maj 2020 17:03:50
// Purpose: Definition of Class PatientController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Model.PatientModel;
using SIMS.Service.UsersService;
using SIMS.Service.MedicalService;

namespace SIMS.Controller.UsersController
{
    public class PatientController : IController<Patient, UserID>
    {
        private PatientService _patientService;
        private MedicalRecordService _medicalRecordService;
        private TherapyService _therapyService;
        private DiagnosisService _diagnosisService;

        public PatientController(PatientService patientService, MedicalRecordService medicalRecordService, TherapyService therapyService, DiagnosisService diagnosisService)
        {
            _patientService = patientService;
            _medicalRecordService = medicalRecordService;
            _therapyService = therapyService;
            _diagnosisService = diagnosisService;
        }

        public MedicalRecord GetMedicalRecordByPatient(Patient patient)
            => _medicalRecordService.GetPatientMedicalRecord(patient);

        public IEnumerable<Patient> GetPatientByType(PatientType patientType)
            => _patientService.GetPatientByType(patientType);

        public IEnumerable<Patient> GetPatientByDoctor(Doctor doctor) 
            => _patientService.GetPatientByDoctor(doctor);

        public IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Patient patient)
            => _diagnosisService.GetAllDiagnosisForPatient(patient);

        public IEnumerable<Therapy> GetFilteredTherapy(Util.TherapyFilter therapyFilter)
            => _therapyService.GetFilteredTherapy(therapyFilter);

        public IEnumerable<Therapy> GetActiveTherapyForPatient(Patient patient)
            => _therapyService.GetActiveTherapyForPatient(patient);

        public Diagnosis AddDiagnosis(Patient patient, Diagnosis diagnosis)
            => _medicalRecordService.AddDiagnosis(patient, diagnosis);

        public IEnumerable<Allergy> GetPatientAllergies(Patient patient)
            => _medicalRecordService.GetPatientAllergies(patient);

        public IEnumerable<Patient> GetAll()
            => _patientService.GetAll();

        public Patient GetByID(UserID id)
            => _patientService.GetByID(id);

        public Patient Create(Patient entity)
            => _patientService.Create(entity);

        public void Update(Patient entity)
            => _patientService.Update(entity);

        public void Delete(Patient entity)
            => _patientService.Delete(entity);

        public Prescription GivePrescription(Therapy therapy, Prescription prescription)
            => _therapyService.SetPerscription(therapy, prescription);
        
    }
}