using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class SupplyRepository : DataRepository<ProductShelf>
    {
        public ProductShelf FindByProduct(int productId)
        {
            using (var db = new DataContext())
            {
                return db.ProductsShelves
                    .Include(e => e.Product)
                    .Include(e => e.Shelf)
                    .Where(e => e.ProductId == productId)
                    .SingleOrDefault();
            }
        }

        public ProductShelf FindByProduct(Product product)
        {
            return FindByProduct(product.Id);
        }

        public int GetAmountInStock(int productId)
        {
            using (var db = new DataContext())
            {
                return db.ProductsShelves
                    .Where(r => r.ProductId == productId)
                    .Select(r => r.CurrentAmount)
                    .SingleOrDefault();
            }
        }
    }
}