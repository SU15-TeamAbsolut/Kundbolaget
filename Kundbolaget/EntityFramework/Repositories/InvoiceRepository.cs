using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class InvoiceRepository : DataRepository<Invoice>
    {
        public override void Create(Invoice item)
        {
            using (var db = new DataContext())
            {
                db.Customers.Attach(item.Customer);
                db.Entry(item.Customer).State = EntityState.Unchanged;

                foreach (var order in item.Orders)
                {
                    db.Orders.Attach(order);
                    db.Entry(order).State = EntityState.Unchanged;
                }

                db.Invoices.Add(item);
                db.SaveChanges();
            }
        }
    }
}