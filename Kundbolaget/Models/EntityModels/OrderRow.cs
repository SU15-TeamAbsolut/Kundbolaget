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
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public decimal Price {get; set;}

        public int AmountOrdered { get; set; }
        public int? AmountShipped { get; set; }
        [NotMapped]  // Used for order rows when fulfilling an order
        public int AmountInStock { get; set; }
    }
}