using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels
{
    public class OrderConfirmationViewModel
    {
        public Order Order { get; set; }
        public Order BackOrder { get; set; }
    }
}