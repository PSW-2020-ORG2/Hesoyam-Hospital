// File:    DiagnosisRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:34
// Purpose: Definition of Class DiagnosisRepository

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class DiagnosisRepository : CSVRepository<Diagnosis, long>, IDiagnosisRepository, IEagerCSVRepository<Diagnosis, long>
    {
        private const string ENTITY_NAME = "Diagnosis";
        private IEagerCSVRepository<Therapy, long> _therapyEagerCSVRepository;
        private IEagerCSVRepository<Disease, long> _diseaseEagerCSVRepository;
        private IMedicalRecordRepository _medicalRecordRepository;

        public DiagnosisRepository(ICSVStream<Diagnosis> stream, ISequencer<long> sequencer, IEagerCSVRepository<Therapy, long> therapyEagerCSVRepository, IEagerCSVRepository<Disease, long> diseaseEagerCSVRepository, IMedicalRecordRepository medicalRecordRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Diagnosis>())
        {
            _therapyEagerCSVRepository = therapyEagerCSVRepository;
            _diseaseEagerCSVRepository = diseaseEagerCSVRepository;
            _medicalRecordRepository = medicalRecordRepository;
        }

      

        public IEnumerable<Diagnosis> GetAllEager()
        {
            IEnumerable<Diagnosis> diagnoses = GetAll();

            Bind(diagnoses);

            return diagnoses;
        }

        public Diagnosis GetEager(long id)
            => GetAllEager().SingleOrDefault(diagnosis => diagnosis.GetId() == id);

        private void Bind(IEnumerable<Diagnosis> diagnosis)
        {
            IEnumerable<Therapy> therapies = _therapyEagerCSVRepository.GetAllEager();
            IEnumerable<Disease> diseases = _diseaseEagerCSVRepository.GetAllEager();

            BindDiagnosisWithDisease(diagnosis, diseases);
            BindDiagnosisWithTherapies(diagnosis, therapies);
        }

        private void BindDiagnosisWithTherapies(IEnumerable<Diagnosis> diagnosis, IEnumerable<Therapy> therapies)
            => diagnosis.ToList().ForEach(diag =>
            {
                diag.Therapies = GetTherapiesByIDS(therapies, diag.Therapies.Select(therapy => therapy.GetId())).ToList();
            });

        private void BindDiagnosisWithDisease(IEnumerable<Diagnosis> diagnosis, IEnumerable<Disease> diseases)
            => diagnosis.ToList().ForEach(diag => diag.DiagnosedDisease = GetDiseaseByID(diseases, diag.DiagnosedDisease.GetId()));


        public IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Patient patient)
        {

            MedicalRecord patientMedicalRecord = _medicalRecordRepository.GetPatientMedicalRecord(patient);

            return patientMedicalRecord.PatientDiagnosis;
        }

        public IEnumerable<Diagnosis> GetDiagnosisByMedicine(Medicine medicine)
        {
            List<Diagnosis> retVal = new List<Diagnosis>();

            IEnumerable<Diagnosis> allDiagnosis = GetAllEager();

            foreach(Diagnosis diagnosis in allDiagnosis)
            {
                
                IEnumerable<Therapy> therapiesForDiagnosis = diagnosis.Therapies; //Therapy contains information about prescriptions.

                foreach(Therapy therapy in therapiesForDiagnosis) 
                {
                    if (therapy.Prescription.Medicine.Keys.Contains(medicine)) //Prescription has information about medicine that is given to the patient.
                        retVal.Add(diagnosis);
                }
            }

            return retVal;

        }


 

        private Disease GetDiseaseByID(IEnumerable<Disease> diseases, long id)
            => diseases.SingleOrDefault(disease => disease.GetId() == id);

        private IEnumerable<Therapy> GetTherapiesByIDS(IEnumerable<Therapy> therapies, IEnumerable<long> ids)
            => therapies.Where(therapy => ids.Contains(therapy.GetId()));

        public TherapyRepository therapyRepository;
        public DiseaseRepository diseaseRepository;

        public IEagerCSVRepository<Therapy, long> TherapyEagerCSVRepository { get => _therapyEagerCSVRepository; set => _therapyEagerCSVRepository = value; }
        public IEagerCSVRepository<Disease, long> DiseaseEagerCSVRepository { get => _diseaseEagerCSVRepository; set => _diseaseEagerCSVRepository = value; }
        public IMedicalRecordRepository MedicalRecordRepository { get => _medicalRecordRepository; set => _medicalRecordRepository = value; }
    }
}