using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kundbolaget.Models.EntityModels
{
    public class Country
    {
        [DisplayName("Land")]
        public int Id { get; set; }
        [DisplayName("Land")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string CountryCode { get; set; }

    }
}