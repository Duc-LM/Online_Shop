using System.Collections.Generic;

namespace Online_Shop.Models.DTO
{
    public class OrderCartProducts
    {
        public List<Product> Product { get; set; }

        public Order Order { get; set; }

        public Order_Product Order_Product { get; set; }
    }
}