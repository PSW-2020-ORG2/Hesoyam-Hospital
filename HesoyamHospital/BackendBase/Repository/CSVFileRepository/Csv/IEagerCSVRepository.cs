// File:    IEagerCSVRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:57:50
// Purpose: Definition of Interface IEagerCSVRepository

using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.Csv
{
    public interface IEagerCSVRepository<T, ID>
    {
        T GetEager(ID id);

        IEnumerable<T> GetAllEager();

    }
}