using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kundbolaget.Models.EntityModels
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ProductNumber { get; set; }

        [Required]
        public int Volume { get; set; }

        [Required]
        public int PackageAmount { get; set; }

        [Required]
        public decimal AlcoholPercentage { get; set; }

        [Required]
        public int AccountingCode { get; set; }

        [Required]
        public int VatCode { get; set; }

        //FK Key
        [Required]
        public int ProductCategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        
    }
}