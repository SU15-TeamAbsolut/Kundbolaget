using System.Collections.Generic;
using System.Data.Entity;
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
                    .Include(c => c.Contact)
                    .Include(l => l.AlcoholLicense)
                    .Include(e => e.Orders)
                    .Include(e => e.Orders.Select(o => o.OrderRows))
                    .SingleOrDefault(c => c.Id == id);
            }
        }
        public override IList<Customer> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.Customers
                    .Include(c => c.InvoiceAddress)
                    .Include(v => v.VisitingAddress)
                    .Include(s => s.ShippingAddresses)
                    .Include(c => c.Contact)
                    .Include(c => c.AlcoholLicense)
                    .Include(e => e.Orders)
                    .ToList();



            }
        }

        public IList<Customer> GetCustomersAlcoLicenses()
        {
            using (var db = new DataContext())
            {
                var customers = db.Customers
                    .Include(a => a.AlcoholLicense).ToList();
                return customers;

            }
        }
    }
}