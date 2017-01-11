using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kundbolaget.Models.EntityModels
{
    public class ProductShelfChangeLog
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Initialer")]
        public string Initials { get; set; }
        [Required]
        [DisplayName("Beskrivning")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Hylla")]
        public int ShelfId { get; set; }
        [ForeignKey("ShelfId")]
        [DisplayName("Hylla")]
        public virtual Shelf Shelf { get; set; }
        [Required]
        [DisplayName("Produkt")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [DisplayName("Produkt")]
        public virtual Product Product { get; set; }
        [Required]
        [DisplayName("Datum")]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Antal")]
        public int Amount { get; set; }
    }
}