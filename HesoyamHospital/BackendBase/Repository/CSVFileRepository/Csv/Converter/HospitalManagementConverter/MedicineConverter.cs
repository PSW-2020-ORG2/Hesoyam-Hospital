// File:    MedicineConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:53:09
// Purpose: Definition of Class MedicineConverter

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    public class MedicineConverter : ICSVConverter<Medicine>
    {
        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";";
        public MedicineConverter()
        {
        }


        public Medicine ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);
            List<Disease> dummyDisease = (tokens[5] == "") ? new List<Disease>() : GetDummyDisease(SplitStringByDelimiter(tokens[5],_listDelimiter));
            List<Ingredient> dummyIngredient = (tokens[6] == "") ? new List<Ingredient>() : GetDummyIngredient(SplitStringByDelimiter(tokens[6], _listDelimiter));
            MedicineType medicineType = (MedicineType)Enum.Parse(typeof(MedicineType), tokens[3]); //Casting string to Enum.

            return new Medicine(
                long.Parse(tokens[0]),
                tokens[1],
                double.Parse(tokens[2]),
                medicineType,
                bool.Parse(tokens[4]),
                dummyDisease,
                dummyIngredient,
                int.Parse(tokens[7]),
                int.Parse(tokens[8]));
        }

        public string ConvertEntityToCSV(Medicine entity)
        => string.Join(
            _delimiter,
            entity.GetId(),
            entity.Name,
            entity.Strength,
            entity.MedicineType,
            entity.IsValid,
            GetDiseaseIDSCSVstring(entity.UsedFor),
            GetIngredientIDSCSVstring(entity.Ingredient),
            entity.InStock,
            entity.MinNumber);

        private string GetDiseaseIDSCSVstring(IEnumerable<Disease> diseaseList)
            => string.Join(_listDelimiter, diseaseList.Select(disease => disease.GetId()));
        private string GetIngredientIDSCSVstring(IEnumerable<Ingredient> ingredientList)
           => string.Join(_listDelimiter, ingredientList.Select(ingredient => ingredient.GetId()));

        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
            => stringToSplit.Split(delimiter.ToCharArray());

        private List<Disease> GetDummyDisease(string[] ids)
            => ids.ToList().ConvertAll(x => new Disease(long.Parse(x)));

        private List<Ingredient> GetDummyIngredient(string[] ids)
            => ids.ToList().ConvertAll(x => new Ingredient(long.Parse(x)));
    }
}