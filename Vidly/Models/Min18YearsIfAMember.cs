using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute

    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId==MembershipType.UNKNOWN || 
                customer.MembershipTypeId == MembershipType.PAY_AS_YOU_GO)
            {
                return ValidationResult.Success;
            }

            if (customer.DateOfBirth == null)
            {
                return new ValidationResult("Date of Birth is Required");
            }

            var age = DateTime.Now.Year - customer.DateOfBirth.Value.Year;
            return (age >= 18) ? 
                ValidationResult.Success : 
                new ValidationResult("Customer must be at least 18 to go on a membership");
        }
    }  
}