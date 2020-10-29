// File:    StatisticsConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:53:09
// Purpose: Definition of Class StatisticsConverter

using System;
using SIMS.Model.ManagerModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    public class StatisticsConverter : ICSVConverter<Stats>
    {
        private string delimiter;
        private string dateTimeFormat;

        public Stats ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Stats entity)
        {
            throw new NotImplementedException();
        }
    }
}