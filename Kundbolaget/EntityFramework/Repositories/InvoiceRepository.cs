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
                    .Include(e => e.Orders)
                    .Include(e => e.Orders.Select(o => o.OrderRows))
                    .ToList();
            }
        }

        public override void Create(Invoice invoice)
        {
            using (var db = new DataContext())
            {
                // TODO: Workaround for lack of invoice address
                if (invoice.Customer.InvoiceAddressId == 0)
                {
                    invoice.InvoiceAdressId = invoice.Customer.VisitingAddressId;
                }

                // Remove customer from object or it'll get duplicated because reasons
                invoice.Customer = null;

                IEnumerable<int> orderIds = invoice.Orders.Select(o => o.Id);
                invoice.Orders = new List<Order>();
                foreach (int id in orderIds)
                {
                    Order order = db.Orders.Find(id);

                    // Set orders to invoiced
                    order.OrderStatus = OrderStatus.Invoiced;
                    invoice.Orders.Add(order);
                }

                db.Invoices.Add(invoice);
                db.SaveChanges();
            }
        }

        public override Invoice Find(int id)
        {
            using (var db = new DataContext())
            {
                return db.Invoices
                    .Include(e => e.Customer)
                    .Include(e => e.InvoiceAddress)
                    .Include(e => e.Orders)
                    .Include(e => e.Orders.Select(o => o.OrderRows))
                    .SingleOrDefault(e => e.Id == id);
            }
        }

    }
}