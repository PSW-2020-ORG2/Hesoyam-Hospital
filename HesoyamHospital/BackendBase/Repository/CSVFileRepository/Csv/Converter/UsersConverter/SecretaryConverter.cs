// File:    SecretaryConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:27
// Purpose: Definition of Class SecretaryConverter

using System;
using System.Globalization;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter
{
    public class SecretaryConverter : ICSVConverter<Secretary>
    {
        private string _delimiter = "?";
        private string _dateTimeFormat = "dd.MM.yyyy.";

        public SecretaryConverter()
        {
        }

        public Secretary ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            Secretary secretary = new Secretary(id: new UserID(tokens[0]),
                                            userName: tokens[1],
                                            password: "" /*tokens[2]*/,
                                            dateCreated: DateTime.ParseExact(tokens[3], _dateTimeFormat, CultureInfo.InvariantCulture),
                                            name: tokens[4],
                                            surname: tokens[5],
                                            middleName: tokens[6],
                                            sex: (Sex)Enum.Parse(typeof(Sex), tokens[7]),
                                            dateOfBirth: tokens[8].Equals("") ? DateTime.MinValue : DateTime.ParseExact(tokens[8], _dateTimeFormat, CultureInfo.InvariantCulture),
                                            uidn: tokens[9],
                                            address: tokens[11].Equals("") ? null : new Address(tokens[10], new Location(long.Parse(tokens[11]), tokens[12], tokens[13])),
                                            homePhone: tokens[14],
                                            cellPhone: tokens[15],
                                            email1: tokens[16],
                                            email2: tokens[17],
                                            timeTable: tokens[18].Equals("") ? null : new TimeTable(long.Parse(tokens[18])),
                                            hospital: tokens[19].Equals("") ? null : new Hospital(long.Parse(tokens[19])));

            return secretary;
        }

        public string ConvertEntityToCSV(Secretary secretary)
            => string.Join(_delimiter,
                    secretary.GetId().ToString(),
                    secretary.UserName,
                    /*secretary.Password*/ "",
                    secretary.DateCreated.ToString(_dateTimeFormat),
                    secretary.Name,
                    secretary.Surname,
                    secretary.MiddleName,
                    secretary.Sex,
                    secretary.DateOfBirth == DateTime.MinValue ? "" : secretary.DateOfBirth.ToString(_dateTimeFormat),
                    secretary.Uidn,
                    secretary.Address == null ? "" : secretary.Address.Street,
                    secretary.Address == null ? "" : (secretary.Address.Location == null ? "" : secretary.Address.Location.GetId().ToString()),
                    secretary.Address == null ? "" : (secretary.Address.Location == null ? "" : secretary.Address.Location.Country),
                    secretary.Address == null ? "" : (secretary.Address.Location == null ? "" : secretary.Address.Location.City),
                    secretary.HomePhone,
                    secretary.CellPhone,
                    secretary.Email1,
                    secretary.Email2,
                    secretary.TimeTable == null ? "" : secretary.TimeTable.GetId().ToString(),
                    secretary.Hospital == null ? "" : secretary.Hospital.GetId().ToString());
    }
}