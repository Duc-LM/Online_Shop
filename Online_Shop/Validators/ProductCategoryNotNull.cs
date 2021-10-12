using Online_Shop.Models;
using System.ComponentModel.DataAnnotations;

namespace Online_Shop.Validators
{
    public class ProductCategoryNotNull : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Product c = (Product)validationContext.ObjectInstance;
            if (c.category_id == null)
            {
                return new ValidationResult("Category_id : not null");
            }

            return null;
        }
    }
}