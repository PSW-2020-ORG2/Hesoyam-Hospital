// File:    MedicineRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:40
// Purpose: Definition of Class MedicineRepository

using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.MedicalRepository;
using SIMS.Repository.Sequencer;
using SIMS.Specifications;
using SIMS.Specifications.Converter;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class MedicineRepository : CSVRepository<Medicine, long>, IMedicineRepository, IEagerCSVRepository<Medicine, long>
    {
        private const string ENTITY_NAME = "Medicine";
        IIngredientRepository _ingredientRepository;
        IDiseaseRepository _diseaseRepository;
        public MedicineRepository(ICSVStream<Medicine> stream, ISequencer<long> sequencer, IIngredientRepository ingredientRepository, IDiseaseRepository diseaseRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Medicine>())
        {
            _ingredientRepository = ingredientRepository;
            _diseaseRepository = diseaseRepository;
        }

        private void BindMedicineWithDisease(IEnumerable<Medicine> medicine, IEnumerable<Disease> disease)
            => medicine.ToList().ForEach(med => 
            {
                med.UsedFor = GetDiseasesByIds(disease, med.UsedFor.Select(dis => dis.Id));
            });

        private List<Disease> GetDiseasesByIds(IEnumerable<Disease> diseases, IEnumerable<long> ids)
            => diseases.Where(dis => ids.Contains(dis.Id)).ToList();



        private void BindMedicineWithIngredients(IEnumerable<Medicine> medicine, IEnumerable<Ingredient> ingredients)
            => medicine.ToList().ForEach(med =>
            {
                med.Ingredient = GetIngredientsByIds(ingredients, med.Ingredient.Select(ingredient => ingredient.Id));
            });

        private List<Ingredient> GetIngredientsByIds(IEnumerable<Ingredient> ingredients, IEnumerable<long> ids)
            => ingredients.Where(ingredient => ids.Contains(ingredient.Id)).ToList();

        private void Bind(IEnumerable<Medicine> medicine)
        {
            BindMedicineWithDisease(medicine, _diseaseRepository.GetAll());
            BindMedicineWithIngredients(medicine, _ingredientRepository.GetAll());
        }

        public IEnumerable<Medicine> GetMedicineForDisease(Disease disease)
            => GetAll().Where(med => med.UsedFor.Contains(disease));

        public IEnumerable<Medicine> GetMedicineByIngredient(Ingredient ingredient)
            => GetAll().Where(med => med.Ingredient.Contains(ingredient));

        public Medicine GetMedicineByName(string name)
            => GetAll().SingleOrDefault(med => med.Name == name);

        public IEnumerable<Medicine> GetFilteredMedicine(MedicineFilter medicineFilter)
        {
            ISpecification<Medicine> medicineSpecification = new MedicineSpecificationConverter(medicineFilter).GetSpecification();
            var meds = Find(medicineSpecification);
            Bind(meds);
            return meds;
        }

        public IEnumerable<Medicine> GetMedicinePendingApproval()
            => GetAll().Where(med => med.IsValid == false);

        public Medicine GetEager(long id)
            => GetAllEager().SingleOrDefault(med => med.Id == id);

        public IEnumerable<Medicine> GetAllEager()
        {
            IEnumerable<Medicine> medicine = GetAll();
            Bind(medicine);
            return medicine;
        }

        public IngredientRepository ingredientRepository;
        public MedicineSpecificationConverter medicineSpecificationConverter;
        public DiseaseRepository diseaseRepository;

        public IIngredientRepository IngredientRepository { get => _ingredientRepository; set => _ingredientRepository = value; }
        public IDiseaseRepository DiseaseRepository { get => _diseaseRepository; set => _diseaseRepository = value; }
    }
}