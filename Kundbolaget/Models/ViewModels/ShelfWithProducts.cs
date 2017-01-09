using Kundbolaget.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kundbolaget.Models.ViewModels
{
    public class ShelfWithProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ProductShelf> Products { get; set; }
    }
}