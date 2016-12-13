using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.ViewModels
{
    public class CountryViewModel
    {
        public Address Address { get; set; }
        public Country Country { get; set; }
        public IList<Country> Countries { get; set; } 

    }
}