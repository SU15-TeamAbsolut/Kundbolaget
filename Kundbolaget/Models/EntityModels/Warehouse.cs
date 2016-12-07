using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kundbolaget.Models.EntityModels
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int ContactId { get; set; }
        public bool IsActive { get; set; }
    }
}