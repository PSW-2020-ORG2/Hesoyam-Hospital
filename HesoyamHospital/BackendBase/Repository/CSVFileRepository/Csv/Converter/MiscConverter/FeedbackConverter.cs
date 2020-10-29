// File:    FeedbackConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:04:00
// Purpose: Definition of Class FeedbackConverter

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class FeedbackConverter : ICSVConverter<Feedback>
    {
        private readonly string _delimiter = "~";
        private readonly string _listDelimiter = "^";
        private readonly string _secondaryListDelimiter = "|";

        public FeedbackConverter()
        {
        }

        public Feedback ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            Feedback feedback = new Feedback(id: long.Parse(tokens[0]),
                                                user: tokens[1].Equals("") ? null : new User(new UserID(tokens[1])),
                                                tokens[2],
                                                GetRating(tokens[3]));

            return feedback;
        }

        private Dictionary<Question, Rating> GetRating(string csv)
        {
            string[] tokens = csv.Split(_listDelimiter.ToCharArray());

            Dictionary<Question, Rating> retVal = new Dictionary<Question, Rating>();

            foreach(string token in tokens)
            {
                if (token.Equals(""))
                    break;

                string[] rating_tokens = token.Split(_secondaryListDelimiter.ToCharArray());
                if (rating_tokens[0].Equals("")) continue;

                Question q = new Question(long.Parse(rating_tokens[0]));
                Rating r = new Rating(rating_tokens[1], rating_tokens[2].Equals("") ? default : int.Parse(rating_tokens[2]));

                retVal.Add(q, r);
            }

            return retVal;
        }

        public string ConvertEntityToCSV(Feedback entity)
            => string.Join(_delimiter,
                entity.GetId(),
                entity.User == null ? "" : entity.User.GetId().ToString(),
                entity.Comment,
                ratingToCSV(entity.Rating)
                );

        private string ratingToCSV(Dictionary<Question, Rating> entity)
            => entity == null ? "" : string.Join(_listDelimiter, entity.Keys.Select(q => GetDictCSV(q, entity[q])));

        private string GetDictCSV(Question q, Rating rating)
            => string.Join(_secondaryListDelimiter, q.GetId(), rating == null ? "" : rating.Comment, rating == null ? "" : rating.Stars.ToString());
    }
}