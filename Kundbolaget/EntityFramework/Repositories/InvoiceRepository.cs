using System.Data.Entity;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Enums;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class InvoiceRepository : DataRepository<Invoice>
    {
        public override void Create(Invoice item)
        {
            using (var db = new DataContext())
            {
                item.Customer = null;

                foreach (var order in item.Orders)
                {
                    order.OrderStatus = OrderStatus.Invoiced;

                    db.Orders.Attach(order);
                    db.Entry(order).State = EntityState.Modified;
                }

                db.Invoices.Add(item);
                db.SaveChanges();
            }
        }
    }
}