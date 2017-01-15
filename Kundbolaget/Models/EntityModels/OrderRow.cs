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
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price {get; set;}
        [DisplayName("Rabatt")]
        public decimal Discount { get; set; }
        [DisplayName("Rabattpris")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DiscountedPrice => Price*(1 - Discount);
        [DisplayName("Antal beställt")]
        public int AmountOrdered { get; set; }
        [DisplayName("Antal skickat")]
        public int? AmountShipped { get; set; }

        [DisplayName("Totalpris beställt")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalOrderedPrice => GetTotalOrderedPrice();

        [DisplayName("Totalpris Levererat")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalShippedPrice => GetTotalDeliveredPrice();

        private decimal GetTotalDeliveredPrice()
        {
            if (AmountShipped != null)
            {
                return DiscountedPrice * AmountShipped.Value;
            }

            return 0;
        }

        private decimal GetTotalOrderedPrice()
        {
            return DiscountedPrice * AmountOrdered;
        }

        // Used for order rows when fulfilling an order
        [NotMapped]
        public int AmountInStock { get; set; }
        [NotMapped]
        public bool IsInStock => (AmountInStock >= AmountOrdered);
    }
}