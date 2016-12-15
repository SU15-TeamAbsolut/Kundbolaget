using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Kundbolaget.EntityFramework.Contexts;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class DataRepository<T> : IRepository<T> where T : class
    {
        public virtual T Find(int id)
        {
            using (var db = new DataContext())
            {
                return db.Set<T>().Find(id);
            }
        }

        public virtual IList<T> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.Set<T>().ToList();
            }
        }
        public virtual IList<T> GetAll(int id)
        {
            using (var db = new DataContext())
            {
                return db.Set<T>().ToList();
            }
        }
        public virtual void Create(T item)
        {
            using (var db = new DataContext())
            {
                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }

        public virtual void Update(T item)
        {
            using (var db = new DataContext())
            {
                db.Set<T>().Attach(item);
                var entry = db.Entry(item);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}