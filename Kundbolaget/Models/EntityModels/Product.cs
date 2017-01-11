using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Kundbolaget.Models.EntityModels
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Namn")]
        public string Name { get; set; }
        [DisplayName("Beskrivning")]
        public string Description { get; set; }

        [NotMapped]
        [DisplayName("Pris")]
        public decimal Price
        {
            get { return GetPrice(); }
            set { SetPrice(value); }
        }

        public virtual IList<ProductPrice> PriceList { get; set; } = new List<ProductPrice>();

        [Required]
        [DisplayName("Volym(ml)")]
        public int Volume { get; set; }

        [Required]
        [DisplayName("Antal/Kolli")]
        public int PackageAmount { get; set; }

        [Required]
        [DisplayName("Alkoholhalt(%)")]
        public decimal AlcoholPercentage { get; set; }

        [Required]
        [DisplayName("Faktureringskod")]
        public int AccountingCode { get; set; }

        [Required]
        [DisplayName("Momskod")]
        public int VatCode { get; set; }

        //FK Key
        [Required]
        public int ProductCategoryId { get; set; }
        [DisplayName("Produktkategori")]
        public virtual ProductCategory ProductCategory { get; set; }

        [NotMapped]
        public int? QuantiyInWarehouse { get; set; }

        [NotMapped]
        public int? QuantiyOrdered { get; set; }

        private decimal GetPrice()
        {
            ProductPrice productPrice = PriceList
                .OrderByDescending(p => p.StartDate)
                .FirstOrDefault(p => p.StartDate <= DateTime.Today);

            if (productPrice == null)
            {
                return 0;
            }

            return productPrice.Price;
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