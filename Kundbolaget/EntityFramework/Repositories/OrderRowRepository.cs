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
                    .Include(p => p.Product.PriceList)
                    .Where(x => x.OrderId == id);
                return orderRows.ToList();
            }
           
        }

        public OrderRow GetOrderRow(int id)
        {
            using (var db = new DataContext())
            {
                return db.OrderRows
                    .Include(o => o.Order)
                    .Include(o => o.Order.Customer)
                    .Include(p => p.Product)
                    .SingleOrDefault(o => o.Id == id);
            }
        }


    }
}