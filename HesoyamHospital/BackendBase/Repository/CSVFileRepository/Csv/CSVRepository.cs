// File:    CSVRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:43:05
// Purpose: Definition of Class CSVRepository

using System;
using System.Collections.Generic;
using System.Linq;
using SIMS.Exceptions;
using SIMS.Repository.Abstract;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using SIMS.Specifications;

namespace SIMS.Repository.CSVFileRepository.Csv
{
    public class CSVRepository<T, ID> : IRepository<T, ID>
        where T : IIdentifiable<ID>
        where ID : IComparable
    {
        private const string NOT_FOUND_ERROR = "{0} with {1}:{2} can not be found!";

        public string _entityName;
        public ICSVStream<T> _stream;
        public ISequencer<ID> _sequencer;
        public IIdGeneratorStrategy<T, ID> _idGeneratorStrategy;

        public CSVRepository(string entityName, ICSVStream<T> stream, ISequencer<ID> sequencer, IIdGeneratorStrategy<T,ID> idGeneratorStrategy)
        {
            _entityName = entityName;
            _stream = stream;
            _sequencer = sequencer;
            _idGeneratorStrategy = idGeneratorStrategy;
            InitializeId();
        }

        public ID GetMaxId(IEnumerable<T> entities)
            => _idGeneratorStrategy.GetMaxId(entities);

        public void InitializeId()
            => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        public IEnumerable<T> GetAll() => _stream.ReadAll();

        public T GetByID(ID id)
        {
            try
            {
                return _stream
                    .ReadAll()
                    .SingleOrDefault(entity => entity.GetId().CompareTo(id) == 0);
            }
            catch (ArgumentException)
            {
                throw new EntityNotFoundException(string.Format(NOT_FOUND_ERROR, _entityName, "id", id));
            }
        }

        public T Create(T entity)
        {
            entity.SetId(_sequencer.GenerateID());
            _stream.AppendToFile(entity);
            return entity;
        }

        public void Update(T entity)
        {
            try
            {
                var entities = _stream.ReadAll().ToList();
                entities[entities.FindIndex(ent => ent.GetId().CompareTo(entity.GetId()) == 0)] = entity;
                _stream.SaveAll(entities);
            }
            catch (ArgumentException)
            {
                ThrowEntityNotFoundException("id", entity.GetId());
            }
        }

        public void Delete(T entity)
        {
            var entities = _stream.ReadAll().ToList();
            var entityToRemove = entities.SingleOrDefault(ent => ent.GetId().CompareTo(entity.GetId()) == 0);
            if (entityToRemove != null)
            {
                entities.Remove(entityToRemove);
                _stream.SaveAll(entities);
            }
            else
            {
                ThrowEntityNotFoundException("id", entity.GetId());
            }
        }

        public IEnumerable<T> Find(ISpecification<T> criteria)
            => _stream.ReadAll().Where(o => criteria.IsSatisfiedBy(o));

        private void ThrowEntityNotFoundException(string key, object value)
          => throw new EntityNotFoundException(string.Format(NOT_FOUND_ERROR, _entityName, key, value));

    }
}