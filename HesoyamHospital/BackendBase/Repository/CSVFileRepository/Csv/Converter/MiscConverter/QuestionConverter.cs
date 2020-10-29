using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class QuestionConverter : ICSVConverter<Question>
    {
        private string _delimiter = "~";

        public Question ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());
            return new Question(long.Parse(tokens[0]), tokens[1]);
        }

        public string ConvertEntityToCSV(Question question)
            => string.Join(_delimiter, question.GetId(), question.Text);
    }
}
