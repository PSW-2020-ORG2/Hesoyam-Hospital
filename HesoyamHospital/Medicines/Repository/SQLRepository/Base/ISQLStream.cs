using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.Repository.SQLRepository.Base
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
