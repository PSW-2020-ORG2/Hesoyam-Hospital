// File:    IngredientRepository.cs
// Author:  nikola
// Created: 24. maj 2020 12:24:56
// Purpose: Definition of Class IngredientRepository

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
    public class IngredientRepository : CSVRepository<Ingredient, long>, IIngredientRepository
    {
        private const string ENTITY_NAME = "Ingredient";
        public IngredientRepository(ICSVStream<Ingredient> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Ingredient>())
        {

        }
    }
}