using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Kundbolaget.Enums;
using Kundbolaget.Models.ViewModels;

namespace Kundbolaget.Models.EntityModels
{
    public class Invoice
    {
        public int Id { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public virtual IList<Order> Orders { get; set; } = new List<Order>();

        [Required]
        public int InvoiceAdressId { get; set; }
        [ForeignKey("InvoiceAdressId")]
        public virtual Address InvoiceAddress { get; set; }

        [Required]
        [DisplayName("Förfallodatum")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DueDate { get; set; }

        [Required]
        public InvoiceStatus InvoiceStatus { get; set; } = InvoiceStatus.Created;
    }
}