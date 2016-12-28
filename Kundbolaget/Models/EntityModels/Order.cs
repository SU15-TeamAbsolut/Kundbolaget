using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Kundbolaget.Enums;

namespace Kundbolaget.Models.EntityModels
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public int? CustomerOrderRef { get; set; }
        [Required]
        public int ShippingAddressId { get; set; }
        [ForeignKey("ShippingAddressId")]
        public virtual Address ShippingAddress { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime OrderPlaced { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DesiredDeliveryDate { get; set;}
        
        public OrderStatus OrderStatus { get; set; }

        public virtual IList<OrderRow> OrderRows { get; set; } = new List<OrderRow>();

        public decimal Total => GetOrderTotal();

        private decimal GetOrderTotal()
        {
            return OrderRows.Sum(r => r.Price * r.AmountOrdered);
        }
    }

    
}