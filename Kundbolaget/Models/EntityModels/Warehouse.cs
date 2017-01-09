using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kundbolaget.Models.EntityModels
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Lagernamn")]
        public string Name { get; set; }
        [Required]
        public int AddressId { get; set; }
        [DisplayName("Adress")]
        public virtual Address Address { get; set; }
        [DisplayName("Kontakt Id")]
        public int ContactId { get; set; }
        public bool IsActive { get; set; }
        public virtual IList<Shelf> Shelfs { get; set; }

        public Warehouse()
        {
            Shelfs = new List<Shelf>();
        }
    }
}