using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Backend.Repository.MySQLRepository.MySQL.Stream
{
    public class MySQLStream<T> : IMySQLStream<T> where T : class
    {
        private readonly static MyDbContext dbContext = new MyDbContext();
        public MySQLStream() {}
        public void Append(T entity)
        {
            var local = dbContext.Set<T>().Local.FirstOrDefault(entry => entry.Equals(entity));

            if (local != null)
            {
                dbContext.Entry(local).State = EntityState.Detached;
            }

            var ret = dbContext.Set<T>().Attach(entity);
            ret.State = EntityState.Added;
            SaveAll();
        }

        public void Update(T entity)
        {
            var local = dbContext.Set<T>().Local.FirstOrDefault(entry => entry.Equals(entity));

            if (local != null)
            {
                dbContext.Entry(local).State = EntityState.Detached;
            }

            dbContext.Entry(entity).State = EntityState.Modified;
            SaveAll();
        }

        public IEnumerable<T> ReadAll()
            =>dbContext.Set<T>().ToList();


        public IEnumerable<T> ReadAllEager()
            => ReadAll().ToList();

        public void SaveAll()
        {
            dbContext.SaveChanges();
        }
    }
}
