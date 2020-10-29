using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model.PatientModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    class IngredientConverter : ICSVConverter<Ingredient>
    {
        private readonly string _delimiter = ",";
        
        public IngredientConverter()
        {
        }

        //private string _name;
        //private long _id;

        public Ingredient ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);
            return new Ingredient(
                long.Parse(tokens[0]),
                tokens[1]
                );
        }

        public string ConvertEntityToCSV(Ingredient entity)
            => string.Join(_delimiter, entity.Id, entity.Name);


        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
           => stringToSplit.Split(delimiter.ToCharArray());
    }
}
