using System.Collections.Generic;

namespace Online_Shop.Models.DTO
{
    public class ProductCategory
    {
        public Productcart Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}