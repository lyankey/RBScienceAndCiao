using ScienceAndCiao.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndCiao.Models
{
    public class MajorityAge : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var member = (Member)validationContext.ObjectInstance;

            if (member.MembershipTypeId == MembershipType.Unknown ||
                member.MembershipTypeId == MembershipType.NoMembership)
                return ValidationResult.Success;

            if (member.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - member.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}