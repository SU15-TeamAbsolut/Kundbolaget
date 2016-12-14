using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class OrderRepository : DataRepository<Order>
    {
        public override void Create(Order order)
        {
            using (var db = new DataContext())
            {
                db.Customers.Attach(order.Customer);
                var entry = db.Entry(order.Customer);
                entry.State = EntityState.Unchanged;

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
                    .Include(c => c.Customer)
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