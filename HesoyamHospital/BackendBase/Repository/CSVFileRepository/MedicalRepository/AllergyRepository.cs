// File:    AllergyRepository.cs
// Author:  nikola
// Created: 24. maj 2020 13:02:09
// Purpose: Definition of Class AllergyRepository

using SIMS.Model.PatientModel;
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
    public class AllergyRepository : CSVRepository<Allergy, long>, IAllergyRepository, IEagerCSVRepository<Allergy,long>
    {
        private const string ENTITY_NAME = "Allergy";
        private IIngredientRepository _ingredientsRepository;
        private ISymptomRepository _symptomsRepository;

        public AllergyRepository(ICSVStream<Allergy> stream, ISequencer<long> sequencer,IIngredientRepository ingredientsRepository,ISymptomRepository symptomsRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Allergy>())
        {
            _ingredientsRepository = ingredientsRepository;
            _symptomsRepository = symptomsRepository;
        }

        public IEnumerable<Allergy> GetAllEager()
        {
            IEnumerable<Allergy> allergies = GetAll();
            IEnumerable<Ingredient> ingredients = _ingredientsRepository.GetAll();
            IEnumerable<Symptom> symptoms = _symptomsRepository.GetAll();

            Bind(allergies, ingredients, symptoms);

            return allergies;
        }

        public Allergy GetEager(long id)
            => GetAllEager().SingleOrDefault(allergy => allergy.GetId() == id);

        private void Bind(IEnumerable<Allergy> allergies, IEnumerable<Ingredient> ingredients, IEnumerable<Symptom> symptoms)
        {
            BindAllergiesWithIngredients(allergies, ingredients);
            BindAllergiesWithSymptoms(allergies, symptoms);
        }

        private void BindAllergiesWithIngredients(IEnumerable<Allergy> allergies, IEnumerable<Ingredient> ingredients)
            => allergies.ToList().ForEach(allergy => allergy.AllergicToIngredient = GetIngredientByID(ingredients, allergy.AllergicToIngredient.Id));

        private void BindAllergiesWithSymptoms(IEnumerable<Allergy> allergies, IEnumerable<Symptom> symptoms)
            => allergies.ToList().ForEach(allergy =>
            {
                allergy.Symptoms = GetSymptomsByIDs(symptoms, allergy.Symptoms.Select(symptom => symptom.GetId())).ToList();
            });

        private Ingredient GetIngredientByID(IEnumerable<Ingredient> ingredients, long id)
            => ingredients.SingleOrDefault(ingredient => ingredient.Id == id);

        private IEnumerable<Symptom> GetSymptomsByIDs(IEnumerable<Symptom> symptoms, IEnumerable<long> ids)
            => symptoms.Where(symptom => ids.Contains(symptom.GetId()));
    }
}