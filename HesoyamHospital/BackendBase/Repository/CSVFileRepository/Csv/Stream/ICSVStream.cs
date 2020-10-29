// File:    ICSVStream.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:45:25
// Purpose: Definition of Interface ICSVStream

using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.Csv.Stream
{
    public interface ICSVStream<T>
    {
        void SaveAll(IEnumerable<T> entities);

        IEnumerable<T> ReadAll();

        void AppendToFile(T enitity);

    }
}