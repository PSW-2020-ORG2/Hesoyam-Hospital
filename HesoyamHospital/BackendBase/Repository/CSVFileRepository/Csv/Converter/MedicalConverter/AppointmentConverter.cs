// File:    AppointmentConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:27
// Purpose: Definition of Class AppointmentConverter

using System;
using SIMS.Model.PatientModel;
using SIMS.Util;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class AppointmentConverter : ICSVConverter<Appointment>
    {
        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";";
        private readonly string _dateTimeFormat = "dd.MM.yyyy. HH:mm";

        public AppointmentConverter()
        {
        }

        public Appointment ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);
            AppointmentType appointmentType = (AppointmentType)Enum.Parse(typeof(AppointmentType), tokens[4]); //Casting string to Enum.

            return new Appointment(
                    long.Parse(tokens[0]),
                    GetDummyDoctor(tokens[1]),
                    GetDummyPatient(tokens[2]),
                    GetDummyRoom(tokens[3]),
                    appointmentType,
                    GetTimeInterval(SplitStringByDelimiter(tokens[5], _listDelimiter)),
                    bool.Parse(tokens[6])
                    );
        }

        public string ConvertEntityToCSV(Appointment entity)
            => string.Join(
                _delimiter,
                entity.GetId(),
                entity.DoctorInAppointment == null ? "" : entity.DoctorInAppointment.GetId().ToString(),
                entity.Patient == null ? "" : entity.Patient.GetId().ToString(),
                entity.Room == null ? "" : entity.Room.GetId().ToString(),
                entity.AppointmentType,
                transformTimeIntervalToCSV(entity.TimeInterval),
                entity.Canceled
                );
        private string transformTimeIntervalToCSV(TimeInterval timeInterval)
            => string.Join(_listDelimiter, timeInterval.StartTime.ToString(_dateTimeFormat), timeInterval.EndTime.ToString(_dateTimeFormat));

        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
            => stringToSplit.Split(delimiter.ToCharArray());

        private Room GetDummyRoom(string id)
            => id.Equals("") ? null : new Room(long.Parse(id));

        private Doctor GetDummyDoctor(string id)
            => id.Equals("") ? null : new Doctor(new UserID(id));

        private Patient GetDummyPatient(string id)
            => id.Equals("") ? null : new Patient(new UserID(id));

        private DateTime GetDateTimeFromString(string dateTime)
            => DateTime.ParseExact(dateTime, _dateTimeFormat, null);

        private TimeInterval GetTimeInterval(string[] timeIntervalCSV)
            => new TimeInterval(GetDateTimeFromString(timeIntervalCSV[0]), GetDateTimeFromString(timeIntervalCSV[1]));
    }
}