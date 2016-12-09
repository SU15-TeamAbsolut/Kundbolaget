using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public int InvoiceAddressId { get; set; }
        [ForeignKey("InvoiceAddressId")]
        public virtual Address InvoiceAddress { get; set; }

        [Required]
        public int VisitingAddressId { get; set; }
        [ForeignKey("VisitingAddressId")]
        public virtual Address VisitingAddress { get; set; }

        [Required]
        public int AlcoholLicenseId { get; set; }
        [ForeignKey("AlcoholLicenseId")]
        public virtual AlcoholLicense AlcoholLicense { get; set; }
    }
}