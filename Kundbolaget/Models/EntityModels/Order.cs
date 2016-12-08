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
        
        [Required]
        public int ShippingAddressId { get; set; }
        [ForeignKey("ShippingAddressId")]
        public virtual Address ShippingAddress { get; set; }

        public DateTime OrderPlaced { get; set; }
        public DateTime DesiredDeliveryDate { get; set;}
        public OrderStatus OrderStatus { get; set; }

        public virtual IList<OrderRow> OrderRows { get; set; }
    }

    
}