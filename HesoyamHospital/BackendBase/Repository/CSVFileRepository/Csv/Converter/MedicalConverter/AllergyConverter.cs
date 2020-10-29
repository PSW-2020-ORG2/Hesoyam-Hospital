using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIMS.Model.PatientModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    class AllergyConverter : ICSVConverter<Allergy>
    {

        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";";

        public AllergyConverter()
        {
        }


        public Allergy ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);

            return new Allergy(
                    long.Parse(tokens[0]),
                    tokens[1],
                    GetDummyIngredient(tokens[2]),
                    tokens[3] == "" ? new List<Symptom>() : GetSymptomListFromCSV(SplitStringByDelimiter(tokens[3], _listDelimiter))
                );
        }
        //public Allergy(long id,string name, Ingredient allergicToIngredient, List<Symptom> symptomList)
        public string ConvertEntityToCSV(Allergy entity)
            => string.Join(_delimiter,
                    entity.GetId(),
                    entity.Name,
                    entity.AllergicToIngredient.GetId(),
                    ConvertSymptomListToCSV(entity.Symptoms)
                );


        private Ingredient GetDummyIngredient(string id)
            => new Ingredient(long.Parse(id));

        private List<Symptom> GetSymptomListFromCSV(string[] ids)
            => ids.ToList().ConvertAll(id => new Symptom(long.Parse(id)));

        private string ConvertSymptomListToCSV(IEnumerable<Symptom> symptoms)
            => string.Join(_listDelimiter, symptoms.Select(symptom => symptom.GetId()));

        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
           => stringToSplit.Split(delimiter.ToCharArray());

    }
}
