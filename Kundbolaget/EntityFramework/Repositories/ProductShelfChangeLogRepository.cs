using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class ProductShelfChangeLogRepository : DataRepository<ProductShelfChangeLog>
    {
        public List<ProductShelfChangeLog> GetLogsByWarehouseId(int warehouseId)
        {
            var db = new DataContext();
            var logs = db.ProductShelfChangeLogs.Where(x => x.Shelf.WarehouseId == warehouseId).Include(x => x.Product).OrderByDescending(x => x.Date).ToList();
            return logs;
        }

        public ProductShelfChangeLog FindAndInclude(int id)
        {
            var db = new DataContext();
            var log = db.ProductShelfChangeLogs.Where(x => x.Id == id).Include(x => x.Product).Include(x => x.Shelf).FirstOrDefault();
            return log;
        }
    }
}