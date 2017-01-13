using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.CustomValidation
{
    public class ValidateOrderedQuantity : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product)validationContext.ObjectInstance;

            if (product.QuantiyOrdered > product.QuantiyInWarehouse)
            {
                return new ValidationResult("Beställt antal överstig antalet i lagret");
            }
            if (product.QuantiyOrdered.Value < 0)
            {
                return new ValidationResult("Beställt antal måste överstiga noll");
            }
            return ValidationResult.Success;
        }
        
    }
    
}