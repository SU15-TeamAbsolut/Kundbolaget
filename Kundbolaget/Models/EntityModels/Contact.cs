using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace Kundbolaget.Models.EntityModels
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Kontaktperson")]
        public string Name { get; set; }

        [Required]
        public int AdressId { get; set; }
        [ForeignKey("AdressId")]
        public virtual Address Address { get; set; }

        [Required]
        [DisplayName("Telefonnummer")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("E-post")]
        public string Email { get; set; }

    }
}