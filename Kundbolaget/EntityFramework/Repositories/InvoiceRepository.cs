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
                item.Customer = null;

                foreach (var order in item.Orders)
                {
                    db.Orders.Attach(order);
                }

                db.Invoices.Add(item);
                db.SaveChanges();
            }
        }
    }
}