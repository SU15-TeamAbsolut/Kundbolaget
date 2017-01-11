using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels
{
    public class ManualOrderViewModel
    {
        public Product[] Products { get; set; } 
        public Customer Customer { get; set; }
        public int ShippingAddressId { get; set; }
        public int InvoiceAddressId { get; set; }
        public Order Order { get; set; }
    }
}