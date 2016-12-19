using System.Collections.Generic;
using Kundbolaget.Models.EntityModels;
using NJsonSchema.Validation;

namespace Kundbolaget.Models.ViewModels
{
    public class JsonOrderViewModel
    {
        public string Json { get; set; }
        public bool OrderIsValid { get; set; } = true;
        public ICollection<ValidationError> ValidationErrors { get; set; }
        public string ErrorMessage { get; set; }
        public Order Order { get; set; }
    }
}