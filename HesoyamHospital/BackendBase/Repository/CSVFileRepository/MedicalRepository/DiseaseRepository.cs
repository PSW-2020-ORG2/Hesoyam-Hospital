// File:    DiseaseRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:34
// Purpose: Definition of Class DiseaseRepository

using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class DiseaseRepository : CSVRepository<Disease, long>, IDiseaseRepository, IEagerCSVRepository<Disease, long>
    {
        private const string ENTITY_NAME = "Disease";
        private ISymptomRepository _symptomRepository;
        private IEagerCSVRepository<Medicine, long> _medicineEagerCSVRepository;

        public ISymptomRepository SymptomRepository { get => _symptomRepository; set => _symptomRepository = value; }
        public IEagerCSVRepository<Medicine, long> MedicineEagerCSVRepository { get => _medicineEagerCSVRepository; set => _medicineEagerCSVRepository = value; }

        public DiseaseRepository(ICSVStream<Disease> stream, ISequencer<long> sequencer, IEagerCSVRepository<Medicine, long> medicineEagerCSVRepository, ISymptomRepository symptomRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Disease>())
        {
            _symptomRepository = symptomRepository;
            _medicineEagerCSVRepository = medicineEagerCSVRepository;
        }

        private void Bind(IEnumerable<Disease> diseases)
        {
            IEnumerable<Medicine> medicines = _medicineEagerCSVRepository.GetAllEager();
            IEnumerable<Symptom> symptoms = _symptomRepository.GetAll();

            BindDiseaseWithMedicine(diseases, medicines);
            BindDiseaseWithSymptom(diseases, symptoms);

        }

        private void BindDiseaseWithMedicine(IEnumerable<Disease> diseases, IEnumerable<Medicine> medicines)
            => diseases.ToList().ForEach(disease =>
                {
                    disease.AdministratedFor = GetMedicinesByIDs(medicines, disease.AdministratedFor.Select(medicine => medicine.GetId())).ToList();
                }
            );

        private void BindDiseaseWithSymptom(IEnumerable<Disease> diseases, IEnumerable<Symptom> symptoms)
           => diseases.ToList().ForEach(disease =>
           {
               disease.Symptoms = GetSymptomsByIDs(symptoms, disease.Symptoms.Select(symptom => symptom.GetId())).ToList();
           });


        public IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<Symptom> symptoms)
            => GetAllEager().Where(disease => !disease.Symptoms.Except(symptoms).Any()); //Performs check if disease.Symptoms contains ALL of symptoms.

        public IEnumerable<Disease> GetDiseasesByType(DiseaseType type)
            => GetAllEager().Where(disease => disease.DiseaseType == type);

        public Disease GetEager(long id)
            => GetAllEager().SingleOrDefault(disease => disease.GetId() == id);

        public IEnumerable<Disease> GetAllEager()
        {
            IEnumerable<Disease> diseases = GetAll();
            Bind(diseases);

            return diseases;
        }



        private IEnumerable<Medicine> GetMedicinesByIDs(IEnumerable<Medicine> medicines , IEnumerable<long> ids)
            => medicines.Where(medicine => ids.Contains(medicine.GetId()));

        private IEnumerable<Symptom> GetSymptomsByIDs(IEnumerable<Symptom> symptoms, IEnumerable<long> ids)
            => symptoms.Where(symptom => ids.Contains(symptom.GetId()));
    }
}