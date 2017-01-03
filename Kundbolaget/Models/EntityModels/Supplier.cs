using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kundbolaget.Models.EntityModels
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Namn")]
        public string Name { get; set; }
        [DisplayName("Telefonnummer")]
        public string Phone { get; set; }
        [DisplayName("E-post")]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int AddressId { get; set; }
        [DisplayName("Leverantörsadress")]
        public virtual Address Address { get; set; }
    }
}