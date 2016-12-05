using System.ComponentModel.DataAnnotations;

namespace Kundbolaget.Models.EntityModels
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
        public int CreditLine { get; set; }
        public int PaymentTerm { get; set; }
        public int AccountingCode { get; set; }
        public long OrganizationNumber { get; set; }
    }
}