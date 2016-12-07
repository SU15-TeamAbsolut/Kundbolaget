using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;
using Kundbolaget.Models.ViewModels;

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

        public void CreateProduct(ProductCategoryViewModel viewModel)
        {
            using (var db = new DataContext())
            {
                var newProduct = new Product()
                {
                    Name = viewModel.Product.Name,
                    ProductCategoryId = viewModel.Product.ProductCategoryId,
                    Description = viewModel.Product.Description,
                    Price = viewModel.Product.Price,
                    ProductNumber = viewModel.Product.ProductNumber,
                    Volume = viewModel.Product.Volume,
                    AlcoholPercentage = viewModel.Product.AlcoholPercentage,
                    AccountingCode = viewModel.Product.AccountingCode,
                    VatCode = viewModel.Product.VatCode
                };
                db.Products.Add(newProduct);
                db.SaveChanges();
            }


        }
    }
}