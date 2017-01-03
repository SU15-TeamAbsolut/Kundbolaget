using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kundbolaget.Models.CustomValidation;

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

        [CorporateIdentityNumber]
        public long OrganizationNumber { get; set; }

      
        public int? InvoiceAddressId { get; set; }
        [ForeignKey("InvoiceAddressId")]
        public virtual Address InvoiceAddress { get; set; }

        [Required]
        public int VisitingAddressId { get; set; }
        [ForeignKey("VisitingAddressId")]
        public virtual Address VisitingAddress { get; set; }

      
        public int? AlcoholLicenseId { get; set; }
        [ForeignKey("AlcoholLicenseId")]
        public virtual AlcoholLicense AlcoholLicense { get; set; }

        public int? ContactId { get; set;}
        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }

        public virtual IList<Address> ShippingAddresses { get; set; }
    }
}