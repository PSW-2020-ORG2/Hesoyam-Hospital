﻿using System.Collections.Generic;

namespace Feedbacks.Service.Abstract
{
    public interface IService<T, ID>
    {
        IEnumerable<T> GetAll();

        T GetByID(ID id);

        T Create(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
