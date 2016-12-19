using System;
using System.Collections.Generic;
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
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [Required]
        public int ShelfId { get; set; }
        [ForeignKey("ShelfId")]
        public virtual Shelf Shelf { get; set; }
        [Required]
        public int CurrentAmount { get; set; }
        [Required]
        public int MinimumAmount { get; set; }
    }
}