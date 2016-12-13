using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class CustomerRepository : DataRepository<Customer>
    {
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