using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Models.CustomValidation
{
    public class ValidateRestOrderDate : ValidationAttribute
    {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var order = (Order)validationContext.ObjectInstance;


                DateTime desiredDeliveryDate = order.DesiredDeliveryDate;

                if (order.DesiredDeliveryDate < order.OrderPlaced)
                {
                    return new ValidationResult("En restorders önskade datum måste vara senare än huvudorderns");
                }

                return ValidationResult.Success;

            }
    }
}