using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kundbolaget.Models.EntityModels
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Gatunamn")]
        public string Street { get; set; }
        [Required]
        [DisplayName("Postnummer")]
        public string ZipNumber { get; set; }
        [Required]
        [DisplayName("Stad")]
        public string City { get; set; }
        [Required]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        [DisplayName("Land")]
        public virtual Country Country { get; set; }

        public override string ToString()
        {
            return $"{Street}, {ZipNumber}, {City}";
        }
    }
}