using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kundbolaget.Models.EntityModels
{
    public class ProductShelf
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Produkt")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [DisplayName("Produkt")]
        public virtual Product Product { get; set; }
        [Required]
        public int ShelfId { get; set; }
        [ForeignKey("ShelfId")]
        public virtual Shelf Shelf { get; set; }
        [Required]
        [DisplayName("Placering")]
        public string Position { get; set; }
        [Required]
        [DisplayName("Antal")]
        public int CurrentAmount { get; set; }
        [Required]
        [DisplayName("Minimum antal")]
        public int MinimumAmount { get; set; }
    }
}