// File:    MessageConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:05:06
// Purpose: Definition of Class MessageConverter

using System;
using SIMS.Model.UserModel;
using System.Globalization;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class MessageConverter : ICSVConverter<Message>
    {
        private readonly string _delimiter = "~";
        private readonly string _dateTimeFormat = "dd.MM.yyyy. HH:mm";

        public MessageConverter()
        {
        }

        public Message ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());
            long tempId = long.Parse(tokens[0]);
            
            return new Message(tempId, 
                tokens[1],
                tokens[2].Equals("") ? null : new User(new UserID(tokens[2])),
                tokens[3].Equals("") ? null : new User(new UserID(tokens[3])), 
                DateTime.ParseExact(tokens[4],_dateTimeFormat,CultureInfo.InvariantCulture), 
                bool.Parse(tokens[5]));
        }

        public string ConvertEntityToCSV(Message entity)
            => string.Join(_delimiter,
                entity.GetId(),
                entity.Text,
                entity.Recipient == null ? "" : entity.Recipient.GetId().ToString(),
                entity.Sender == null ? "" : entity.Sender.GetId().ToString(),
                entity.Date.ToString(_dateTimeFormat),
                entity.Opened
                );
    }
}