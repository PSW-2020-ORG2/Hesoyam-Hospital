// File:    ILocationRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:07:21
// Purpose: Definition of Interface ILocationRepository

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.MiscAbstractRepository
{
    public interface ILocationRepository : IRepository<Location, long>
    {
        // TODO: Izbrisati sa modela
        //IEnumerable<Location> GetLocationByCountry(Country country);

        IEnumerable<string> GetAllCountries();

        IEnumerable<Location> GetLocationByCountry(string country);

    }
}