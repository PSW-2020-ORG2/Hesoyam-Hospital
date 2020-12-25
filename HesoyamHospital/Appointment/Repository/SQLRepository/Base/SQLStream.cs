using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Appointments.Repository.SQLRepository.Base
{
    public class SQLStream<T> : ISQLStream<T> where T : class
    {
        private MyDbContext dbContext;
        public SQLStream() { dbContext = new MyDbContext(); }
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

        public void Delete(T entity)
        {
            dbContext.Dispose();
            dbContext = new MyDbContext();
            var ret = dbContext.Set<T>().Attach(entity);
            ret.State = EntityState.Deleted;
            SaveAll();
        }
    }
}
