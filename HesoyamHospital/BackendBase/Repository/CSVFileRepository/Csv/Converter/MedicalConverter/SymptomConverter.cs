// File:    SymptomConverter.cs
// Author:  Geri
// Created: 23. maj 2020 19:53:46
// Purpose: Definition of Class SymptomConverter

using System;
using SIMS.Model.PatientModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class SymptomConverter : ICSVConverter<Symptom>
    {
        private readonly string _delimiter = ",";

        public SymptomConverter()
        {
        }

        public Symptom ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);

            return new Symptom(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2]
                );

        }

        public string ConvertEntityToCSV(Symptom entity)
            => string.Join(
                _delimiter,
                entity.GetId(),
                entity.Name,
                entity.ShortDescription
                );

        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
           => stringToSplit.Split(delimiter.ToCharArray());
    }
}