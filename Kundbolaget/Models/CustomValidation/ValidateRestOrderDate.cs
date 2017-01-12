﻿using System;
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

                if (order.DesiredDeliveryDate < order.OrderPlaced)
                {
                    return new ValidationResult("Önskat leveransdatum kan inte vara tidigare än orderns mottagna dataum");
                }

                return ValidationResult.Success;

            }
    }
}