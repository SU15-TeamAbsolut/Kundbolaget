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
        [DisplayName("Ref. nummer")]
        public int? CustomerOrderRef { get; set; }
        [Required]
        public int ShippingAddressId { get; set; }
        [ForeignKey("ShippingAddressId")]
        [DisplayName("Leveransadress")]
        public virtual Address ShippingAddress { get; set; }

        public int? InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }

        [DisplayName("Order mottagen")]
        public DateTime OrderPlaced { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Önskat leveransdatum")]
        [ValidateRestOrderDate]
        public DateTime DesiredDeliveryDate { get; set;}

        [DisplayName("Status")]
        public OrderStatus OrderStatus { get; set; }

        public virtual IList<OrderRow> OrderRows { get; set; } = new List<OrderRow>();

        /// <summary>
        /// Total cost for the entire order, including discounts
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalOrdered => GetTotalOrdered();

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalDelivered => GetTotalDelivered();

        private decimal GetTotalDelivered()
        {
            return OrderRows.Sum(r => r.TotalShippedPrice);
        }

        private decimal GetTotalOrdered()
        {
            return OrderRows.Sum(r => r.TotalOrderedPrice);
        }
    }

    
}