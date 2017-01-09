using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels
{
    public class ShippingAdressViewModel
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}