using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class ProductRepository : DataRepository<Product>
    {
        public IList<Product> SearchByName(string searchString)
        {
            using (var db = new DataContext())
            {
                return db.Products
                    .Where(p => p.Name.Contains(searchString))
                    .Include(p => p.ProductCategory)
                    .ToList();
            }
        }
    }
}