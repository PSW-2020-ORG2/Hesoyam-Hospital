using System.Collections.Generic;

namespace Medicines.Repository.Abstract
{
    public interface IRepository<T, ID>
    {
        IEnumerable<T> GetAll();

        T GetByID(ID id);

        T Create(T entity);

        void Update(T entity);

        void UpdateProperty(T entity, string propertyName);

        void Delete(T entity);
    }
}