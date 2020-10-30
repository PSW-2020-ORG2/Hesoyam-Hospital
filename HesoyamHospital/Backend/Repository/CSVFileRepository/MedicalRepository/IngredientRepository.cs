// File:    IngredientRepository.cs
// Author:  nikola
// Created: 24. maj 2020 12:24:56
// Purpose: Definition of Class IngredientRepository

using Backend.Model.PatientModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.CSVFileRepository.Csv;
using Backend.Repository.CSVFileRepository.Csv.IdGenerator;
using Backend.Repository.CSVFileRepository.Csv.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;


using System.Linq;

namespace Backend.Repository.CSVFileRepository.MedicalRepository
{
    public class IngredientRepository : CSVRepository<Ingredient, long>, IIngredientRepository
    {
        private const string ENTITY_NAME = "Ingredient";
        public IngredientRepository(ICSVStream<Ingredient> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Ingredient>())
        {

        }
    }
}