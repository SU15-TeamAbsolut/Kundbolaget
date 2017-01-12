using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Kundbolaget.EntityFramework.Repositories
{
    public class ProductShelfRepository : DataRepository<ProductShelf>
    {
        public List<ProductShelf> GetProductsShelvesByShelfId(int shelfId)
        {
            using (var db = new DataContext())
            {
                var productsShelves = db.ProductsShelves.Where(x => x.ShelfId == shelfId).Include(x => x.Product).ToList();
                return productsShelves;
            }
        }

        public ProductShelf FindByProductIdAndShelfId(int productId, int shelfId)
        {
            using (var db = new DataContext())
            {
                var productShelf = db.ProductsShelves.Where(x => x.ProductId == productId && x.ShelfId == shelfId).FirstOrDefault();
                return productShelf;
            }
        }

        public int GetProductStock(int productId, int warehouse = 0)
        {
            using (var db = new DataContext())
            {
                return db.ProductsShelves
                    .Where(p => p.ProductId == productId)
                    .Select(p => p.CurrentAmount)
                    .DefaultIfEmpty()
                    .Sum();
            }
        }
    }
}