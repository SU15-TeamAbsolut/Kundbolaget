using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Kundbolaget.Models.EntityModels
{
    public class OrderRow
    {
        public int Id { get; set; }
        [Required]

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [Required]
        [DisplayName("Produkt Id")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [DisplayName("Pris")]
        public decimal Price {get; set;}
        [DisplayName("Rabatt")]
        public decimal Discount { get; set; }
        public decimal DiscountedPrice => Price*(1 - Discount);
        [DisplayName("Antal beställt")]
        public int AmountOrdered { get; set; }
        [DisplayName("Antal skickat")]
        public int? AmountShipped { get; set; }

        // Used for order rows when fulfilling an order
        [NotMapped]
        public int AmountInStock { get; set; }
        [NotMapped]
        public bool IsInStock => (AmountInStock >= AmountOrdered);
    }
}