// File:    ICSVConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:49:23
// Purpose: Definition of Interface ICSVConverter

using System;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter
{
    public interface ICSVConverter<T>
    {
        string ConvertEntityToCSV(T entity);

        T ConvertCSVToEntity(string csv);

    }
}