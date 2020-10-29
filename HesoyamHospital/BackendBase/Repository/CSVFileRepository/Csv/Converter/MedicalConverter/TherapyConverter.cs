// File:    TherapyConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:28
// Purpose: Definition of Class TherapyConverter

using System;
using SIMS.Model.PatientModel;
using SIMS.Util;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class TherapyConverter : ICSVConverter<Therapy>
    {
        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";";
        private readonly string _dateTimeFormat = "dd.MM.yyyy. HH:mm";

        public TherapyConverter()
        {
        }

        public Therapy ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);

            return new Therapy(
                long.Parse(tokens[0]),
                GetTimeInterval(SplitStringByDelimiter(tokens[1],_listDelimiter)),
                GetDummyPrescription(tokens[2])
              );
        }

        public string ConvertEntityToCSV(Therapy entity)
        => string.Join(
               _delimiter,
               entity.GetId(),
               transformTimeIntervalToCSV(entity.TimeInterval),
               entity.Prescription.GetId()
            );

        private string transformTimeIntervalToCSV(TimeInterval timeInterval)
           => string.Join(_listDelimiter, timeInterval.StartTime.ToString(_dateTimeFormat), timeInterval.EndTime.ToString(_dateTimeFormat));

        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
           => stringToSplit.Split(delimiter.ToCharArray());

        private DateTime transformStringToDate(string date)
           => DateTime.ParseExact(date, _dateTimeFormat, null);

        private TimeInterval GetTimeInterval(string[] timeIntervalCSV)
           => new TimeInterval(transformStringToDate(timeIntervalCSV[0]), transformStringToDate(timeIntervalCSV[1]));

        private Prescription GetDummyPrescription(string id)
           => new Prescription(long.Parse(id));
    }
}