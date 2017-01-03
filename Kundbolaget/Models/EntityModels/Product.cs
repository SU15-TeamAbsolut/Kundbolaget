using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Kundbolaget.Models.EntityModels
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public decimal Price
        {
            get { return GetPrice(); }
            set { SetPrice(value); }
        }

        public virtual IList<ProductPrice> PriceList { get; set; } = new List<ProductPrice>();

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

        private decimal GetPrice()
        {
            return PriceList
                .OrderByDescending(p => p.StartDate)
                .First(p => p.StartDate <= DateTime.Today)
                .Price;
        }

        private void SetPrice(decimal value)
        {
            PriceList.Add(new ProductPrice
            {
                Price = value,
                ProductId = this.Id,
                StartDate = DateTime.Now
            });
        }
    }
}