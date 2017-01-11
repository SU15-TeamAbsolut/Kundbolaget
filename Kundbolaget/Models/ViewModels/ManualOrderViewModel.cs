﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels
{
    public class ManualOrderViewModel
    {
        public IList<Product> Products { get; set; } = new List<Product>();
        public int? QuantityOrdered { get; set; }
        
    }
}