using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class ShelfRepository : DataRepository<Shelf>
    {
        public List<Shelf> GetShelfsByWarehouseId(int warehouseId)
        {
            using (var db = new DataContext())
            {
                var shelfs = db.Shelves.Where(x => x.WarehouseId == warehouseId).ToList();
                return shelfs;
            }
        }
    }
}