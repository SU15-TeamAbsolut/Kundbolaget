using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;
using System.Data.Entity;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class OrderRowRepository : DataRepository<OrderRow>
    {
        public override IList<OrderRow> GetAll(int id)
        {
            using (var db = new DataContext())
            {
                var orderRows = db.OrderRows
                    .Include(p => p.Product)
                    .Where(x => x.OrderId == id);
                return orderRows.ToList();
            }
           
        }


    }
}