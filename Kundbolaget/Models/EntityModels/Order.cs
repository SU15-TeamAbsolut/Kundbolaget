using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Kundbolaget.Enums;
using Kundbolaget.Models.CustomValidation;

namespace Kundbolaget.Models.EntityModels
{
    public class Order
    {
        [DisplayName("Order Id")]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        [DisplayName("Kundreferens.nr")]
        public int? CustomerOrderRef { get; set; }
        [Required]
        public int ShippingAddressId { get; set; }
        [ForeignKey("ShippingAddressId")]
        [DisplayName("Leveransadress")]
        public virtual Address ShippingAddress { get; set; }

        public int? InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Order mottagen")]
        public DateTime OrderPlaced { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Önskat leveransdatum")]
        [ValidateRestOrderDate]
        public DateTime DesiredDeliveryDate { get; set;}

        [DisplayName("Status")]
        public OrderStatus OrderStatus { get; set; }

        public virtual IList<OrderRow> OrderRows { get; set; } = new List<OrderRow>();

        public decimal Total => GetOrderTotal();

        private decimal GetOrderTotal()
        {
            return OrderRows.Sum(r => r.DiscountedPrice * r.AmountOrdered);
        }
    }

    
}