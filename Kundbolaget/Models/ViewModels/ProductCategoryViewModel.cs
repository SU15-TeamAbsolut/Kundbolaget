using System.Collections.Generic;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels
{
    public class ProductCategoryViewModel
    {
        public IList<ProductCategory> ProductCategories{ get; set; }
        public IList<Product> Products { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Product Product { get; set; }
        
    }
}