using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels
{
    public class PickListRow
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int AmountOrdered { get; set; }
        public string ShelfName { get; set; }
        public string ShelfSpace { get; set; }
        public int Balance { get; set; }
        public bool IsPickable => (Balance >= AmountOrdered);

    }
}