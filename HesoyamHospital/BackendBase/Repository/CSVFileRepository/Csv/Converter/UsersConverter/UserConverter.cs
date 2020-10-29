// File:    UserConverter.cs
// Author:  nikola
// Created: 26. maj 2020 22:09:02
// Purpose: Definition of Class UserConverter

using SIMS.Model.UserModel;
using System;
using System.Globalization;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter
{
    public class UserConverter : ICSVConverter<User>
    {
        private string _delimiter = "^";
        private string _dateTimeFormat = "dd.MM.yyyy. HH:mm:ss";

        public UserConverter()
        {
        }

        public User ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            User user = new User(id: new UserID(tokens[0]),
                                    username: tokens[1],
                                    password: tokens[2],
                                    dateCreated: DateTime.ParseExact(tokens[3], _dateTimeFormat, CultureInfo.InvariantCulture),
                                    deleted: bool.Parse(tokens[4]));

            return user;
        }

        public string ConvertEntityToCSV(User user)
            => string.Join(_delimiter,
                            user.GetId().ToString(),
                            user.UserName,
                            user.Password,
                            user.DateCreated.ToString(_dateTimeFormat),
                            user.Deleted);
    }
}