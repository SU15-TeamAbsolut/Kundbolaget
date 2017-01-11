using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels
{
    public class ProductListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public int PackageAmount { get; set; }
        public decimal AlcoholPercentage { get; set; }
        public int AccountingCode { get; set; }
        public int VatCode { get; set; }

        public int ProductCategoryId { get; set; }

        // New properties in view model
        public int CurrentStock { get; set; }

        public static ProductListItemViewModel FromProduct(Product product)
        {
            return new ProductListItemViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Volume = product.Volume,
                PackageAmount = product.PackageAmount,
                AlcoholPercentage = product.AlcoholPercentage,
                VatCode = product.VatCode,
                AccountingCode = product.AccountingCode,
                ProductCategoryId = product.ProductCategoryId,
            };
        }
    }
}