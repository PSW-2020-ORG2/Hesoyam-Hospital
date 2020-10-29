// File:    ArticleConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:02:36
// Purpose: Definition of Class ArticleConverter

using System;
using System.Text;
using System.Globalization;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class ArticleConverter : ICSVConverter<Article>
    {
        private string _delimiter = "~";
        private string _dateTimeFormat = "dd.MM.yyyy. HH:mm";

        public ArticleConverter()
        {
        }

        public Article ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            Article retVal = new Article(long.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], tokens[4].Equals("") ? null : new Employee(new UserID(tokens[4])), DateTime.ParseExact(tokens[5],_dateTimeFormat,CultureInfo.InvariantCulture));
            return retVal;
        }

        public string ConvertEntityToCSV(Article article)
            => string.Join(_delimiter,
                article.GetId(),
                article.Title,
                article.ShortDescription,
                article.Text,
                article.Author == null ? "" : article.Author.GetId().ToString(),
                article.Date.ToString(_dateTimeFormat));
    }
}