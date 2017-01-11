using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Kundbolaget.Models.EntityModels
{
    public class AlcoholLicense
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Startdatum")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Slutdatum")]
        public DateTime EndDate { get; set; }

        [Required]
        [DisplayName("Status")]
        [Column("IsActive")]
        public bool IsActive { get; set; } = true;

        [DisplayName("Giltighet")]
        public bool IsValid => CheckValidLicense();

        private bool CheckValidLicense()
        {
            return IsActive
                && DateTime.Today <= EndDate;
        }
    }
}
