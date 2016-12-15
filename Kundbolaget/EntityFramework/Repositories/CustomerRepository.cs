﻿using System.Data.Entity;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;
using System.Linq;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class CustomerRepository : DataRepository<Customer>
    {
        public override Customer Find(int id)
        {
            using (var db = new DataContext())
            {
                return db.Customers
                    .Include(c => c.InvoiceAddress)
                    .Include(v => v.VisitingAddress)
                    .Include(s => s.ShippingAddresses)
                    .SingleOrDefault(c => c.Id == id);
            }
        }
    }
}