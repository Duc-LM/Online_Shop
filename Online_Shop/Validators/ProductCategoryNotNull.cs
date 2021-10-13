﻿using Online_Shop.Models;
using System.ComponentModel.DataAnnotations;

namespace Online_Shop.Validators
{
    public class ProductCategoryNotNull : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Product c = (Product)validationContext.ObjectInstance;
            if (c.Category_id == null)
            {
                return new ValidationResult("Category_id : nust not null!");
            }
            return null;
        }
    }
}