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
                // Attach entities so they don't get duplicated as new entities
                db.Customers.Attach(order.Customer);
                db.Entry(order.Customer).State = EntityState.Unchanged;

                db.Addresses.Attach(order.ShippingAddress);
                db.Entry(order.ShippingAddress).State = EntityState.Unchanged;

                db.Orders.Add(order);
                db.SaveChanges();
            }
        }
    }
}