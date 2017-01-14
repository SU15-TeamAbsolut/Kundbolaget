using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Enums;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class InvoiceRepository : DataRepository<Invoice>
    {
        public override IList<Invoice> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.Invoices
                    .Include(e => e.Customer)
                    .Include(e => e.InvoiceAddress)
                    .ToList();
            }
        }

        public override void Create(Invoice item)
        {
            using (var db = new DataContext())
            {
                item.Customer = null;

                IEnumerable<int> orderIds = item.Orders.Select(o => o.Id);
                item.Orders = new List<Order>();
                foreach (int id in orderIds)
                {
                    item.Orders.Add(db.Orders.Find(id));
                }

                db.Invoices.Add(item);
                db.SaveChanges();
            }
        }
    }
}