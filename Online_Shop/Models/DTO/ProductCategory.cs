using System.Collections.Generic;

namespace Online_Shop.Models.DTO
{
    public class ProductCategory
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}