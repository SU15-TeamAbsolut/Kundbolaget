using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kundbolaget.Models.EntityModels
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IList<Product> Products { get; set; }
    }

}