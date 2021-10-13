using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shop.Validators
{
    public class PromotionNotExist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Promotion p = (Promotion)validationContext.ObjectInstance;
            ShopEntities db = new ShopEntities();
            Promotion result = db.Promotions.Where(promotion => promotion.Name == p.Name).FirstOrDefault();
            if(result != null)
            {
                return new ValidationResult("This name existed in Database");
            }
            return null;
        }
    }
}