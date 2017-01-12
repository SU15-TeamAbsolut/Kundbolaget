using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels.Invoice
{
    public class CreateInvoiceViewModel
    {
        public Customer Customer { get; set; }
        public IList<Order> InvoicableOrders { get; set; } = new List<Order>();
    }
}