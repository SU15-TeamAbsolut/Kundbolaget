using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.ViewModels
{
    public class ProductCategoryViewModel
    {
        public IList<ProductCategory> ProductCategories{ get; set; }
        public IList<Product> Products { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Product Product { get; set; }
        
    }
}