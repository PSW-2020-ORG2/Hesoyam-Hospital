// File:    LocationConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:04:31
// Purpose: Definition of Class LocationConverter

using System;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class LocationConverter : ICSVConverter<Location>
    {
        private string _delimiter = ",";

        public LocationConverter()
        {
        }

        public Location ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());
            long tempId = long.Parse(tokens[0]);
            return new Location(tempId, tokens[1], tokens[2]);
        }

        public string ConvertEntityToCSV(Location entity)
            => string.Join(_delimiter,
                entity.GetId(),
                entity.Country,
                entity.City
                );
    }
}