using System.Collections.Generic;
using System.ComponentModel;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels
{
    public class ProductCategoryViewModel
    {
        public IList<ProductCategory> ProductCategories{ get; set; }
        public IList<Product> Products { get; set; }
        [DisplayName("Produktkategori")]
        public ProductCategory ProductCategory { get; set; }
        public Product Product { get; set; }
        
    }
}