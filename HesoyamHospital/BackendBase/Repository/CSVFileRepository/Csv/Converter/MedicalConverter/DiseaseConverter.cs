// File:    DiseaseConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:27
// Purpose: Definition of Class DiseaseConverter

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class DiseaseConverter : ICSVConverter<Disease>
    {
        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";";


        public DiseaseConverter()
        {
        }

        public Disease ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);

            return new Disease(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2],
                bool.Parse(tokens[3]),
                transformCSVtoDiseaseType(SplitStringByDelimiter(tokens[4], _listDelimiter)),
                (tokens[5] == "" ? new List<Symptom>() : GetSymptomListFromCSV(SplitStringByDelimiter(tokens[5], _listDelimiter))),
                (tokens[6] == "" ? new List<Medicine>() : GetMedicineListFromCSV(SplitStringByDelimiter(tokens[6], _listDelimiter)))
                );
        }

        public string ConvertEntityToCSV(Disease entity)
            => string.Join(
                    _delimiter,
                    entity.GetId(),
                    entity.Name,
                    entity.Overview,
                    entity.IsChronic,
                    transformDiseaseTypeToCSV(entity.DiseaseType),
                    GetSymptomCSVstring(entity.Symptoms),
                    GetMedicineCSVstring(entity.AdministratedFor)

                );


        private string GetMedicineCSVstring(List<Medicine> medicines)
           => string.Join(_listDelimiter, medicines.Select(medicine => medicine.GetId()));
        private List<Medicine> GetMedicineListFromCSV(string[] ids)
           => ids.ToList().ConvertAll(x => new Medicine(long.Parse(x)));

        private string GetSymptomCSVstring(List<Symptom> symptoms)
            => string.Join(_listDelimiter, symptoms.Select(symptom => symptom.GetId()));

        private List<Symptom> GetSymptomListFromCSV(string[] ids)
            => ids.ToList().ConvertAll(id => new Symptom(long.Parse(id)));

        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
          => stringToSplit.Split(delimiter.ToCharArray());
        
        private string transformDiseaseTypeToCSV(DiseaseType diseaseType)
            => string.Join(_listDelimiter, diseaseType.Infectious, diseaseType.Genetic, diseaseType.Type);

        private DiseaseType transformCSVtoDiseaseType(string[] diseaseTypeCSV)
            => new DiseaseType(bool.Parse(diseaseTypeCSV[0]), bool.Parse(diseaseTypeCSV[1]), diseaseTypeCSV[2]);
    }
}