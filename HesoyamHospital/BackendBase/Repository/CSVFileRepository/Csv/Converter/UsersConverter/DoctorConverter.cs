// File:    DoctorConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:24
// Purpose: Definition of Class DoctorConverter

using System;
using System.Globalization;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter
{
    public class DoctorConverter : ICSVConverter<Doctor>
    {
        private string _delimiter = "?";
        private string _dateTimeFormat = "dd.MM.yyyy.";

        public DoctorConverter()
        {
        }

        public Doctor ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            Doctor doc = new Doctor(id: new UserID(tokens[0]),
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
                                    hospital: tokens[19].Equals("") ? null : new Hospital(long.Parse(tokens[19])),
                                    office: tokens[20].Equals("") ? null : new Room(long.Parse(tokens[20])),
                                    doctorType: (DoctorType)Enum.Parse(typeof(DoctorType), tokens[21]));

            return doc;
        }

        public string ConvertEntityToCSV(Doctor doctor)
            => string.Join(_delimiter,
                doctor.GetId().ToString(),
                doctor.UserName,
                /*doctor.Password*/ "",
                doctor.DateCreated.ToString(_dateTimeFormat),
                doctor.Name,
                doctor.Surname,
                doctor.MiddleName,
                doctor.Sex,
                doctor.DateOfBirth == DateTime.MinValue ? "" : doctor.DateOfBirth.ToString(_dateTimeFormat),
                doctor.Uidn,
                doctor.Address == null ? "" : doctor.Address.Street,
                doctor.Address == null ? "" : (doctor.Address.Location == null ? "" : doctor.Address.Location.GetId().ToString()),
                doctor.Address == null ? "" : (doctor.Address.Location == null ? "" : doctor.Address.Location.Country),
                doctor.Address == null ? "" : (doctor.Address.Location == null ? "" : doctor.Address.Location.City),
                doctor.HomePhone,
                doctor.CellPhone,
                doctor.Email1,
                doctor.Email2,
                doctor.TimeTable == null ? "" : doctor.TimeTable.GetId().ToString(),
                doctor.Hospital == null ? "" : doctor.Hospital.GetId().ToString(),
                doctor.Office == null ? "" : doctor.Office.GetId().ToString(),
                doctor.DoctorType);
    }
}