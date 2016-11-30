using System.ComponentModel.DataAnnotations;

namespace Kundbolaget.Models.EntityModels
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}