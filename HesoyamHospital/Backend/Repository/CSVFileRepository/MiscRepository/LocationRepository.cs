// File:    LocationRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:33:21
// Purpose: Definition of Class LocationRepository

using Backend.Model.UserModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Repository.CSVFileRepository.Csv;
using Backend.Repository.CSVFileRepository.Csv.IdGenerator;
using Backend.Repository.CSVFileRepository.Csv.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.CSVFileRepository.MiscRepository
{
    public class LocationRepository : CSVRepository<Location, long>, ILocationRepository
    {
        private const string ENTITY_NAME = "Location";
        public LocationRepository(ICSVStream<Location> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Location>())
        {
        }

        public IEnumerable<string> GetAllCountries()
            => GetAll().Select(l => l.Country).Distinct();

        public IEnumerable<Location> GetLocationByCountry(string country)
            => GetAll().ToList().Where(location => location.Country == country);

    }
}