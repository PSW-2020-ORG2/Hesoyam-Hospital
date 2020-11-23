using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Backend.Repository.MySQLRepository.MySQL.Stream
{
    public class MySQLStream<T> : IMySQLStream<T> where T : class
    {
        private static MyDbContext dbContext = new MyDbContext();
        public MySQLStream()
        {
        }
        public void Append(T entity)
        {
            var ret = dbContext.Set<T>().Attach(entity);
            ret.State = EntityState.Added;
            SaveAll();
        }

        public void Update(T entity)
        {
            SaveAll();
        }

        public IEnumerable<T> ReadAll()
            => dbContext.Set<T>();

        public IEnumerable<T> ReadAllEager()
        {
            IQueryable<T> query = dbContext.Set<T>();
            var properties = typeof(T).GetProperties();
            query = IncludeProperties(query, properties);
            return query;
        }

        private IQueryable<T> IncludeProperties(IQueryable<T> query, PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                var c = properties.FirstOrDefault(c => c.Name == property.Name + "Id"
                || c.Name == property.Name + "ID"
                || c.Name == property.Name + "id");
                if (c != null)
                {
                    query = query.Include(property.Name);
                }
            }
            return query;
        }

        public void SaveAll()
        {
            dbContext.SaveChanges();
        }
    }
}
