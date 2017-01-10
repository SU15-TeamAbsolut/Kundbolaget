using System;
using System.Collections.Generic;
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

        [Required]
        public IList<Order> Orders { get; set; } = new List<Order>();

        [Required]
        public int InvoiceAdressId { get; set; }
        [ForeignKey("InvoiceAdressId")]
        public Address InvoiceAddress { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public InvoiceStatus InvoiceStatus { get; set; }
    }
}