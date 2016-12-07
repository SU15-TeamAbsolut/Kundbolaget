using System.Collections.Generic;
using System.Web.Mvc;

namespace Kundbolaget.Models.ViewModels
{
    public class CreateSupplierViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int AddressId { get; set; }
        public IEnumerable<SelectListItem> AddressList { get; set; }
    }
}