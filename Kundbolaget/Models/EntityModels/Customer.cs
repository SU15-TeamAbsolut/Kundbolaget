using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kundbolaget.Models.CustomValidation;

namespace Kundbolaget.Models.EntityModels
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Namn")]
        public string Name { get; set; }
        [DisplayName("Lösenord")]
        public string Password { get; set; }
        [DisplayName("Kreditgräns")]
        public int CreditLine { get; set; }
        [DisplayName("Betalningsvillkor")]
        public int PaymentTerm { get; set; }
        [DisplayName("Faktureringskod")]
        public int AccountingCode { get; set; }

        [CorporateIdentityNumber]
        [DisplayName("Org.nummer")]
        public long OrganizationNumber { get; set; }

      
        public int? InvoiceAddressId { get; set; }
        [ForeignKey("InvoiceAddressId")]
        public virtual Address InvoiceAddress { get; set; }

        [Required]
        public int VisitingAddressId { get; set; }
        [ForeignKey("VisitingAddressId")]
        [DisplayName("Besöksadress")]
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