// File:    TherapyRepository.cs
// Author:  nikola
// Created: 24. maj 2020 11:52:17
// Purpose: Definition of Class TherapyRepository

using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using Backend.Specifications.Converter;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Specifications;

namespace Backend.Repository.MySQLRepository.MedicalRepository
{
    public class TherapyRepository : MySQLRepository<Therapy, long>, ITherapyRepository, IEagerRepository<Therapy, long>
    {
        private const string ENTITY_NAME = "Therapy";
        private IEagerRepository<Prescription, long> _prescriptionEagerCSVRepository;
        private IEagerRepository<MedicalRecord, long> _medicalRecordEagerCSVRepository;
        private IMedicalRecordRepository _medicalRecordRepository;
        private IDiagnosisRepository _diagnosisCSVRepository;


        public TherapyRepository(IMySQLStream<Therapy> stream, ISequencer<long> sequencer, IEagerRepository<MedicalRecord, long> medicalRecordEagerRepository, IMedicalRecordRepository medicalRecordRepository, IEagerRepository<Prescription, long> prescriptionEagerCSVRepository, IDiagnosisRepository diagnosisCSVRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Therapy>())
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

        public IEagerRepository<Prescription, long> PrescriptionEagerCSVRepository { get => _prescriptionEagerCSVRepository; set => _prescriptionEagerCSVRepository = value; }
        public IEagerRepository<MedicalRecord, long> MedicalRecordEagerCSVRepository { get => _medicalRecordEagerCSVRepository; set => _medicalRecordEagerCSVRepository = value; }
        public IMedicalRecordRepository MedicalRecordRepository { get => _medicalRecordRepository; set => _medicalRecordRepository = value; }
        public IDiagnosisRepository DiagnosisCSVRepository { get => _diagnosisCSVRepository; set => _diagnosisCSVRepository = value; }

        private IEnumerable<Therapy> GetTherapiesByIDs(IEnumerable<Therapy> therapies, IEnumerable<long> ids)
            => therapies.Where(therapy => ids.Contains(therapy.GetId()));

    }
}