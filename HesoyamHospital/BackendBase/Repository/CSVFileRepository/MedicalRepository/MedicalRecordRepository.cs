// File:    MedicalRecordRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:35
// Purpose: Definition of Class MedicalRecordRepository

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class MedicalRecordRepository : CSVRepository<MedicalRecord, long>, IMedicalRecordRepository, IEagerCSVRepository<MedicalRecord, long>
    {
        private const string ENTITY_NAME = "MedicalRecord";
        private IPatientRepository _patientRepository;
        private IDiagnosisRepository _diagnosisRepository;
        private IAllergyRepository _allergyRepository;

        public IPatientRepository PatientRepository { get => _patientRepository; set => _patientRepository = value; }
        public IDiagnosisRepository DiagnosisRepository { get => _diagnosisRepository; set => _diagnosisRepository = value; }
        public IAllergyRepository AllergyRepository { get => _allergyRepository; set => _allergyRepository = value; }

        public MedicalRecordRepository(ICSVStream<MedicalRecord> stream, ISequencer<long> sequencer, IPatientRepository patientRepository, IDiagnosisRepository diagnosisRepository, IAllergyRepository allergyRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<MedicalRecord>())
        {
            _patientRepository = patientRepository;
            _diagnosisRepository = diagnosisRepository;
            _allergyRepository = allergyRepository;
        }

        private void Bind(IEnumerable<MedicalRecord> medicalRecords, IEnumerable<Patient> patients, IEnumerable<Diagnosis> diagnoses, IEnumerable<Allergy> allergies ) 
        {
            BindMedicalRecordsWithAllergies(medicalRecords, allergies);
            BindMedicalRecordsWithDiagnosis(medicalRecords, diagnoses);
            BindMedicalRecordsWithPatients(medicalRecords, patients);
        }

        private void BindMedicalRecordsWithDiagnosis(IEnumerable<MedicalRecord> medicalRecords, IEnumerable<Diagnosis> diagnosis)
            => medicalRecords.ToList().ForEach(medicalRecord =>
            {
                medicalRecord.PatientDiagnosis = GetDiagnosisByIds(diagnosis, medicalRecord.PatientDiagnosis.Select(diag => diag.GetId())).ToList();
            });

        private void BindMedicalRecordsWithAllergies(IEnumerable<MedicalRecord> medicalRecords, IEnumerable<Allergy> allergies)
            => medicalRecords.ToList().ForEach(medicalRecord =>
           {
               medicalRecord.Allergy = GetAlergiesByIds(allergies, medicalRecord.Allergy.Select(allergy => allergy.GetId())).ToList();
           });

        private void BindMedicalRecordsWithPatients(IEnumerable<MedicalRecord> medicalRecords, IEnumerable<Patient> patients)
            => medicalRecords.ToList().ForEach(medicalRecord => medicalRecord.Patient = GetPatientById(patients, medicalRecord.Patient.GetId()));

        public MedicalRecord GetPatientMedicalRecord(Patient patient)
            => GetAllEager().SingleOrDefault(medicalRecord => medicalRecord.Patient.Equals(patient));

        public MedicalRecord GetEager(long id)
            => GetAllEager().SingleOrDefault(medicalRecord => medicalRecord.GetId() == id);

        public IEnumerable<MedicalRecord> GetAllEager()
        {
            IEnumerable<MedicalRecord> medicalRecords = GetAll();

            IEnumerable<Patient> patients = _patientRepository.GetAll();
            IEnumerable<Diagnosis> diagnoses = _diagnosisRepository.GetAll();
            IEnumerable<Allergy> allergies = _allergyRepository.GetAll();

            Bind(medicalRecords, patients, diagnoses, allergies);

            return medicalRecords;
        }

        private IEnumerable<Diagnosis> GetDiagnosisByIds(IEnumerable<Diagnosis> diagnoses, IEnumerable<long> ids)
            => diagnoses.Where(diagnosis => ids.Contains(diagnosis.GetId()));

        private IEnumerable<Allergy> GetAlergiesByIds(IEnumerable<Allergy> allergies, IEnumerable<long> ids)
            => allergies.Where(allergy => ids.Contains(allergy.GetId()));

        private Patient GetPatientById(IEnumerable<Patient> patients, UserID id)
            => patients.ToList().SingleOrDefault(patient => patient.GetId().Equals(id));
    }
}