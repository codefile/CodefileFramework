using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace GenericRepository
{
    public class GenericRepository<TContext> : Interfaces.IGerericRepository
        where TContext : DbContext, new ()
    {
        private readonly TContext _context;

        public TContext Context { get { return _context; } }

        public GenericRepository()
        {
            _context = new TContext();
        }

        public T Insert<T>(T item, bool saveNow = true) where T : class, new()
        {
            return ExecutarAcao(item, EntityState.Added, saveNow);
        }

        public T Update<T>(T item, bool saveNow = true) where T : class, new()
        {
            return ExecutarAcao(item, EntityState.Modified, saveNow);
        }

        public T Delete<T>(T item, bool saveNow = true) where T : class, new()
        {
            return ExecutarAcao(item, EntityState.Deleted, saveNow);
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

        protected virtual T ExecutarAcao<T>(T item, EntityState entityState, bool save = true) where T : class, new()
        {
            _context.Entry(item).State = entityState;
            if (save)
                _context.SaveChanges();

            return item;
        }
    }
}
