using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace GenericRepository
{
    public class GenericRepository<TContext> : Interfaces.IGerericRepository
        where TContext : DbContext, new ()
    {

        public TContext Context { get; private set; }

        public GenericRepository()
        {
            Context = new TContext();
        }

        public T Insert<T>(T item, bool saveNow) where T : class
        {
            Context.Entry(item).State = System.Data.EntityState.Added;
            if (saveNow)
                Context.SaveChanges();

            return item;
        }

        public T Update<T>(T item, bool saveNow) where T : class
        {
            Context.Entry(item).State = System.Data.EntityState.Modified;
            if (saveNow)
                Context.SaveChanges();

            return item;
        }

        public T Delete<T>(T item, bool saveNow) where T : class
        {
            Context.Entry(item).State = System.Data.EntityState.Deleted;
            if (saveNow)
                Context.SaveChanges();

            return item;
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public IEnumerable<T> Select<T>()
            where T :class
        {
            return Context.Set<T>();
        }
    }
}
