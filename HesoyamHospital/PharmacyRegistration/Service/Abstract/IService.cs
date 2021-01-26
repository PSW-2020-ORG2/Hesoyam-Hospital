using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyRegistration.Service.Abstract
{
    public interface IService<T, ID>
    {
        IEnumerable<T> GetAll();

        T GetByID(ID id);

        T Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Validate(T entity);
    }
}
