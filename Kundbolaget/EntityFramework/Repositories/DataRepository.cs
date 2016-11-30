using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class DataRepository<T> : IRepository<T> where T : class
    {
        public T Find(int id)
        {
            using (var db = new DataContext())
            {
                return db.Set<T>().Find(id);
            }
        }

        public IList<T> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.Set<T>().ToList();
            }
        }

        public void Create(T item)
        {
            using (var db = new DataContext())
            {
                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }

        public void Update(T item)
        {
            using (var db = new DataContext())
            {
                db.Set<T>().Attach(item);
                var entry = db.Entry(item);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}