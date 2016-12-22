using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Kundbolaget.Models.EntityModels;
using NJsonSchema.Validation;

namespace Kundbolaget.Models.CustomValidation
{
    public class CorporateIdentityNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            string corporateIdentityNumber = customer.OrganizationNumber.ToString();

            if (corporateIdentityNumber.Length < 10)
            {
                return new ValidationResult("Organisationsnummret måste innehålla tio siffror");
            }
           
            return (IsValidLuhn(corporateIdentityNumber)) 
                ? ValidationResult.Success 
                : new ValidationResult("Organisationsnummret är ogiltigt");
        }
        protected  bool IsValidLuhn(string number)
        {
            int[] deltas = { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };
            int checksum = 0;
            char[] chars = number.ToCharArray();
            for (int i = chars.Length - 1; i > -1; i--)
            {
                int j = chars[i] - 48;
                checksum += j;
                if ((i - chars.Length) % 2 == 0)
                    checksum += deltas[j];
            }
            return (checksum % 10) == 0;
        }
    }
}