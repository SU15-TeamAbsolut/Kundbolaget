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
    public class DataRepository : IRepository
    {
        public Supplier Find(int id)
        {
            using (var db = new DataContext())
            {
                return db.Suppliers.SingleOrDefault(s => s.Id == id);
            }
        }

        public IList<Supplier> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.Suppliers.ToList();
            }
        }

        public void Create(Supplier item)
        {
            throw new NotImplementedException();
        }

        public void Update(Supplier item)
        {
            using (var db = new DataContext())
            {
                db.Suppliers.Attach(item);
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