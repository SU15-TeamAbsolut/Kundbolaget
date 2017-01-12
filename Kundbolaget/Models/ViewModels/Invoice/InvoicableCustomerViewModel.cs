﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.Enums;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels.Invoice
{
    public class InvoicableCustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Order> InvoicableOrders { get; set; }

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