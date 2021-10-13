using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shop.Validators
{
    public class PromotionValidateDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Promotion c = (Promotion)validationContext.ObjectInstance;
            var result = DateTime.Compare(c.Begin_date, c.End_date);
            if (result > 0)
            {
                return new ValidationResult("End Date must later than Begin Date");
            }

            return null;
        }
    }
}