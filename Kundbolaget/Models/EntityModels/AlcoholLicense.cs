using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Kundbolaget.Models.EntityModels
{
    public class AlcoholLicense
    {
        public int Id { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime EndDate { get; set; }
        [Required]
        public bool IsValid { get; set; }
        //public virtual Customer Customers { get; set; }
        //public virtual Address ShippingAddresses { get; set; }

    }
}
