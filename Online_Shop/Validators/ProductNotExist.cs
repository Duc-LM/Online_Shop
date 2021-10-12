using Online_Shop.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Online_Shop.Validators
{
    public class ProductNotExist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Product p = (Product)validationContext.ObjectInstance;
            ShopEntities db = new ShopEntities();
            Product result = db.Products.Where(category => category.Name == p.Name).FirstOrDefault();
            if (result != null)
            {
                return new ValidationResult("This name existed in Database");
            }

            return null;
        }
    }
}