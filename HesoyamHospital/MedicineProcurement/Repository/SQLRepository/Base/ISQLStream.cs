﻿using System.Collections.Generic;

namespace MedicineProcurement.Repository.SQLRepository.Base
{
    public interface ISQLStream<T>
    {
        void SaveAll();

        IEnumerable<T> ReadAll();

        IEnumerable<T> ReadAllEager();

        void Append(T entity);

        void Update(T entity);

        void Delete(T entity);

        void UpdateProperty(T entity, string propertyName);
    }
}
