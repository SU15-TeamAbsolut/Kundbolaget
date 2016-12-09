using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kundbolaget.Models.EntityModels
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string ZipNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public override string ToString()
        {
            return $"{Street}, {ZipNumber}, {City}";
        }
    }
}