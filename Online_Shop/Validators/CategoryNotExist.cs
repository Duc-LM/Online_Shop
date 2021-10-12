using Online_Shop.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Online_Shop.Validators.CategoryValidation
{
    public class CategoryNotExist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Category c = (Category)validationContext.ObjectInstance;
            ShopEntities db = new ShopEntities();
            Category result = db.Categories.Where(category => category.name == c.name).FirstOrDefault();
            if (result != null)
            {
                return new ValidationResult("This name existed in Database");
            }

            return null;
        }
    }
}