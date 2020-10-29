// File:    SymptomRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:35
// Purpose: Definition of Class SymptomRepository

using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class SymptomRepository : CSVRepository<Symptom, long>, ISymptomRepository
    {
        private const string ENTITY_NAME = "Symptom";
        public SymptomRepository(ICSVStream<Symptom> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Symptom>())
        {

        }
    }
}