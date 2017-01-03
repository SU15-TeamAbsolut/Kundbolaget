using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        [Required]
        [DisplayName("Pris")]
        public decimal Price { get; set; }

        [Required]
        [DisplayName("Produktnummer")]
        public int ProductNumber { get; set; }

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
        
    }
}