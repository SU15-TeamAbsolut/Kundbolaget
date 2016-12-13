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
                    .SingleOrDefault(c => c.Id == id);
            }
        }
        public Customer FindCustomer(int? id)
        {

            using (var db = new DataContext())
            {
                var model = db.Customers
                    .Include(w => w.VisitingAddress)
                    .SingleOrDefault(w => w.Id == id);

                return model;
            }

        }

    }
}