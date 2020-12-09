using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.MySQL.Stream
{
    public class MySQLStream<T> : IMySQLStream<T> where T : class
    {
        private MyDbContext dbContext;
        public MySQLStream() { dbContext = new MyDbContext(); }
        public void Append(T entity)
        {
            dbContext.Dispose();
            dbContext = new MyDbContext();
            var ret = dbContext.Set<T>().Attach(entity);
            ret.State = EntityState.Added;
            SaveAll();
        }

        public void Update(T entity)
        {
            dbContext.Dispose();
            dbContext = new MyDbContext();
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            SaveAll();
        }

        public void UpdateProperty(T entity, string propertyName)
        {
            dbContext.Dispose();
            dbContext = new MyDbContext();
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry(entity).Member(propertyName).EntityEntry.State = EntityState.Modified;
            SaveAll();
        }

        public IEnumerable<T> ReadAll()
        {
            dbContext.Dispose();
            dbContext = new MyDbContext();
            return dbContext.Set<T>().ToList();
        }


        public IEnumerable<T> ReadAllEager()
            => ReadAll().ToList();

        public void SaveAll()
        {
            dbContext.SaveChanges();
            dbContext.Dispose();
            dbContext = new MyDbContext();
        }
    }
}
