using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kundbolaget.Models.EntityModels
{
    public class ProductPrice
    {
        public int Id { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }
}