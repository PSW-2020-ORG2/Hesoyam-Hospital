// File:    LocationController.cs
// Author:  nikola
// Created: 22. maj 2020 17:30:10
// Purpose: Definition of Class LocationController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.MiscService;

namespace SIMS.Controller.MiscController
{
    public class LocationController : IController<Location, long>
    {

        private LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        public IEnumerable<Location> GetLocationByCountry(string country)
            => _locationService.GetLocationByCountry(country);

        public IEnumerable<string> GetAllCountries()
            => _locationService.GetAllCountries();

        public IEnumerable<Location> GetAll()
            => _locationService.GetAll();

        public Location GetByID(long id)
            => _locationService.GetByID(id);

        public Location Create(Location entity)
            => _locationService.Create(entity);

        public void Update(Location entity)
            => _locationService.Update(entity);

        public void Delete(Location entity)
            => _locationService.Delete(entity);

    }
}