using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels
{
    public class PickListViewModel
    {
        public int OrderId { get; set; }
        public IList<PickListRow> OrderRows { get; set; }
    }
}