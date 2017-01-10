using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Enums;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class OrderRepository : DataRepository<Order>
    {
        public override void Create(Order order)
        {
            using (var db = new DataContext())
            {
                // Attach entities so they don't get duplicated as new entities
                if (order.Customer != null)
                {
                    db.Customers.Attach(order.Customer);
                    db.Entry(order.Customer).State = EntityState.Unchanged;
                }

                if (order.ShippingAddress != null)
                {
                    db.Addresses.Attach(order.ShippingAddress);
                    db.Entry(order.ShippingAddress).State = EntityState.Unchanged;
                }

                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public override Order Find(int id)
        {
            using (var db = new DataContext())
            {
                return db.Orders
                    .Include(o => o.OrderRows)
                    .Include(e => e.OrderRows.Select(r => r.Product))
                    .Include(c => c.Customer)
                    .Include(c => c.Customer.Contact)
                    .Include(a => a.Customer.VisitingAddress)
                    .Include(a => a.ShippingAddress)
                    .SingleOrDefault(x => x.Id == id);
            }

        }

        public override IList<Order> GetAll()
        {
            using (var db = new DataContext())
            {
                var orders = db.Orders
                    .Include(s => s.ShippingAddress)
                    .Include(c => c.Customer)
                    .Include(o => o.OrderRows);

                return orders.ToList();
            }
        }
    }
}