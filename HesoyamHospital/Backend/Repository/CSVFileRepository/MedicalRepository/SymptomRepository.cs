// File:    SymptomRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:35
// Purpose: Definition of Class SymptomRepository

using Backend.Model.PatientModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.CSVFileRepository.Csv;
using Backend.Repository.CSVFileRepository.Csv.IdGenerator;
using Backend.Repository.CSVFileRepository.Csv.Stream;
using Backend.Repository.Sequencer;
using System;

namespace Backend.Repository.CSVFileRepository.MedicalRepository
{
    public class SymptomRepository : CSVRepository<Symptom, long>, ISymptomRepository
    {
        private const string ENTITY_NAME = "Symptom";
        public SymptomRepository(ICSVStream<Symptom> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Symptom>())
        {

        }
    }
}