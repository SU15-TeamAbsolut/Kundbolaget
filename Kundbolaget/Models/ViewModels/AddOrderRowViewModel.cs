using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Kundbolaget.Models.ViewModels
{
    public class AddOrderRowViewModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [DisplayName("Antal")]
        public int Amount { get; set; }

        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}