// File:    TherapyRepository.cs
// Author:  nikola
// Created: 24. maj 2020 11:52:17
// Purpose: Definition of Class TherapyRepository

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using SIMS.Specifications.Converter;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using SIMS.Specifications;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class TherapyRepository : CSVRepository<Therapy, long>, ITherapyRepository, IEagerCSVRepository<Therapy, long>
    {
        private const string ENTITY_NAME = "Therapy";
        private IEagerCSVRepository<Prescription, long> _prescriptionEagerCSVRepository;
        private IEagerCSVRepository<MedicalRecord, long> _medicalRecordEagerCSVRepository;
        private IMedicalRecordRepository _medicalRecordRepository;
        private IDiagnosisRepository _diagnosisCSVRepository;


        public TherapyRepository(ICSVStream<Therapy> stream, ISequencer<long> sequencer, IEagerCSVRepository<MedicalRecord, long> medicalRecordEagerRepository, IMedicalRecordRepository medicalRecordRepository, IEagerCSVRepository<Prescription, long> prescriptionEagerCSVRepository, IDiagnosisRepository diagnosisCSVRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Therapy>())
        {
            _prescriptionEagerCSVRepository = prescriptionEagerCSVRepository;
            _medicalRecordEagerCSVRepository = medicalRecordEagerRepository;
            _medicalRecordRepository = medicalRecordRepository;
            _diagnosisCSVRepository = diagnosisCSVRepository;
        }

        public Therapy GetEager(long id)
            => GetAllEager().SingleOrDefault(therapy => therapy.GetId() == id);

        public IEnumerable<Therapy> GetAllEager()
        {
            IEnumerable<Therapy> therapies = GetAll();
            Bind(therapies);

            return therapies;
        }

        private void Bind(IEnumerable<Therapy> therapies){
            IEnumerable<Prescription> prescriptions = _prescriptionEagerCSVRepository.GetAllEager();
            BindTherapyWithPrescription(therapies, prescriptions);
        }

        private void BindTherapyWithPrescription(IEnumerable<Therapy> therapies, IEnumerable<Prescription> prescriptions)
            => therapies.ToList().ForEach(therapy => therapy.Prescription = GetPrescriptionByID(prescriptions, therapy.Prescription.GetId()));

        public IEnumerable<Therapy> GetTherapyByDate(TimeInterval dateRange) //Return all therapies where therapy time interval is inside passed time interval(dateRange).
            => GetAllEager().Where(therapy => dateRange.IsDateTimeBetween(therapy.TimeInterval));

        public IEnumerable<Therapy> GetTherapyByMedicine(Medicine medicine)
            => GetAllEager().Where(therapy => therapy.Prescription.Medicine.Keys.Contains(medicine));

        public IEnumerable<Therapy> GetTherapyByPatient(Patient patient)
        {
            List<Therapy> retVal = new List<Therapy>();
            IEnumerable<Diagnosis> diagnosisList = _diagnosisCSVRepository.GetAllDiagnosisForPatient(patient);

            foreach (Diagnosis diagnosis in diagnosisList)
                retVal.AddRange(diagnosis.Therapies);


            return retVal;
        }

        public IEnumerable<Therapy> GetFilteredTherapy(TherapyFilter filter)
        {
            ISpecification<Therapy> therapySpecification = new TherapySpecificationConverter(filter).GetSpecification();
            IEnumerable <Therapy> therapies = Find(therapySpecification);
            Bind(therapies);

            return therapies;
        }

        public IEnumerable<Therapy> GetTherapyByDiagnosis(Diagnosis diagnosis)
            => diagnosis.Therapies;

        public IEnumerable<Therapy> GetActiveTherapyForPatient(Patient patient)
        {
            List<Therapy> retVal = new List<Therapy>();

            IEnumerable<Diagnosis> diagnosisList = _diagnosisCSVRepository.GetAllDiagnosisForPatient(patient);

            foreach (Diagnosis diagnosis in diagnosisList)
                retVal.AddRange(diagnosis.ActiveTherapy);

            return retVal;
        }

        public IEnumerable<Therapy> GetPastTherapyForPatient(Patient patient)
        {
            List<Therapy> retVal = new List<Therapy>();

            IEnumerable<Diagnosis> diagnosisList = _diagnosisCSVRepository.GetAllDiagnosisForPatient(patient);

            foreach (Diagnosis diagnosis in diagnosisList)
                retVal.AddRange(diagnosis.InactiveTherapy);

            return retVal;
        }

        public IEnumerable<Therapy> GetActiveTherapyForDiagnosis(Diagnosis diagnosis)
            => diagnosis.ActiveTherapy;

        public IEnumerable<Therapy> GetPastTherapiesForDiagnosis(Diagnosis diagnosis)
            => diagnosis.InactiveTherapy;


        private Prescription GetPrescriptionByID(IEnumerable<Prescription> prescriptions, long id)
            => prescriptions.SingleOrDefault(prescription => prescription.GetId() == id);

        public TherapySpecificationConverter therapySpecificationConverter;

        public IEagerCSVRepository<Prescription, long> PrescriptionEagerCSVRepository { get => _prescriptionEagerCSVRepository; set => _prescriptionEagerCSVRepository = value; }
        public IEagerCSVRepository<MedicalRecord, long> MedicalRecordEagerCSVRepository { get => _medicalRecordEagerCSVRepository; set => _medicalRecordEagerCSVRepository = value; }
        public IMedicalRecordRepository MedicalRecordRepository { get => _medicalRecordRepository; set => _medicalRecordRepository = value; }
        public IDiagnosisRepository DiagnosisCSVRepository { get => _diagnosisCSVRepository; set => _diagnosisCSVRepository = value; }

        private IEnumerable<Therapy> GetTherapiesByIDs(IEnumerable<Therapy> therapies, IEnumerable<long> ids)
            => therapies.Where(therapy => ids.Contains(therapy.GetId()));

    }
}