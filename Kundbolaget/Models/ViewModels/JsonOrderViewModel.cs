using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;
using NJsonSchema.Validation;

namespace Kundbolaget.Models.ViewModels
{
    public class JsonOrderViewModel
    {
        public string Json { get; set; }
        public bool OrderIsValid { get; set; }
        public ICollection<ValidationError> ValidationErrors { get; set; }
        public string ErrorMessage { get; set; }
        public Order Order { get; set; }
    }
}