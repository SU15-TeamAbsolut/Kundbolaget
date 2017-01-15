using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels
{
    public class ManualOrderViewModel
    {
        public IList<Product> Products { get; set; } = new List<Product>();
        public Customer Customer { get; set; }
        public Order Order { get; set; }


        public bool ValidateOrder(ManualOrderViewModel viewModel)
        {
            foreach (var product in viewModel.Products)
            {
                if (product.QuantiyOrdered != 0)
                {
                    return true;
                }

            }
            return false;
        }
    }

}