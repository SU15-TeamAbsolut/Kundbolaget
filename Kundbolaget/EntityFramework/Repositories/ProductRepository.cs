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
        public override Product Find(int id)
        {
            using (var db = new DataContext())
            {
                return db.Products
                    .Include(p => p.PriceList)
                    .SingleOrDefault(p => p.Id == id);
            }
        }

        public override IList<Product> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.Products
                    .Include(p => p.PriceList)
                    .ToList();
            }
        }


        public IList<Product> SearchByName(string searchString)
        {
            using (var db = new DataContext())
            {
                return db.Products
                    .Where(p => p.Name.Contains(searchString))
                    .Include(p => p.ProductCategory)
                    .Include(p => p.PriceList)
                    .ToList();
            }
        }

        public Product CreateModel(ProductCategoryViewModel viewModel)
        {
                var newProduct = new Product()
                {
                    Name = viewModel.Product.Name,
                    ProductCategoryId = viewModel.Product.ProductCategoryId,
                    Description = viewModel.Product.Description,
                    PriceList = viewModel.Product.PriceList,
                    Volume = viewModel.Product.Volume,
                    PackageAmount = viewModel.Product.PackageAmount,
                    AlcoholPercentage = viewModel.Product.AlcoholPercentage,
                    AccountingCode = viewModel.Product.AccountingCode,
                    VatCode = viewModel.Product.VatCode
                };
            return newProduct;
        }
    }
}