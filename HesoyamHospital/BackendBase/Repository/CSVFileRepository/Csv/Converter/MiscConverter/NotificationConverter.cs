// File:    NotificationConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:05:43
// Purpose: Definition of Class NotificationConverter

using System;
using SIMS.Model.UserModel;
using System.Globalization;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class NotificationConverter : ICSVConverter<Notification>
    {
        private readonly string _delimiter = "~";
        private readonly string _newLineDelimiter = "|";
        private readonly string _dateTimeFormat = "dd.MM.yyyy. HH:mm";

        public NotificationConverter()
        {
        }

        public Notification ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());
            long tempId = long.Parse(tokens[0]);
            return new Notification(tempId, 
                tokens[1].Replace(_newLineDelimiter, "\n"), 
                tokens[2].Equals("") ? null : new User(new UserID(tokens[2])), 
                DateTime.ParseExact(tokens[3],_dateTimeFormat,CultureInfo.InvariantCulture));
        }

        public string ConvertEntityToCSV(Notification entity)
            => string.Join(_delimiter,
                entity.GetId(),
                entity.Text.Replace("\n", _newLineDelimiter),
                entity.Recipient == null ? "" : entity.Recipient.GetId().ToString(),
                entity.Date.ToString(_dateTimeFormat)
                );
    }
}