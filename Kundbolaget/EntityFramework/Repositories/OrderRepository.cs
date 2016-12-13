using System.Data.Entity;
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
    }
}