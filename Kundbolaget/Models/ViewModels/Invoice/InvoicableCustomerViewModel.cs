using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Kundbolaget.Enums;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels.Invoice
{
    public class InvoicableCustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Order> InvoicableOrders { get; set; } = new List<Order>();
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal OrderTotal => GetOrderTotal();

        private decimal GetOrderTotal()
        {
            if (!InvoicableOrders.Any())
            {
                return 0;
            }

            return InvoicableOrders
                .SelectMany(o => o.OrderRows)
                .Sum(r => r.DiscountedPrice * (r.AmountShipped ?? 0));
        }

        public static InvoicableCustomerViewModel FromCustomer(Customer customer)
        {
            return new InvoicableCustomerViewModel
            {
                Customer = customer,
                InvoicableOrders = customer.Orders
                    .Where(o => o.OrderStatus == OrderStatus.Delivered)
                    .ToList()
            };
        }
    }
}