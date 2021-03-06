﻿using MedicineProcurement.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineProcurement.Repository.SQLRepository.Base
{
    public class SQLRepository<T, ID> : IRepository<T, ID> where T : class where ID : IComparable
    {
        public ISQLStream<T> _stream;

        public SQLRepository(ISQLStream<T> stream)
        {
            _stream = stream;
        }

        public SQLRepository() { }

        public T Create(T entity)
        {
            _stream.Append(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _stream.Delete(entity);
        }

        public IEnumerable<T> GetAll()
            => _stream.ReadAllEager();

        public T GetByID(ID id) =>
            GetAll().SingleOrDefault(entity => ((IComparable)entity.GetType().GetProperty("Id").GetValue(entity)).CompareTo(id) == 0);

        public void Update(T entity)
        {
            _stream.Update(entity);
        }

        public void UpdateProperty(T entity, string propertyName)
        {
            _stream.UpdateProperty(entity, propertyName);
        }
    }
}
