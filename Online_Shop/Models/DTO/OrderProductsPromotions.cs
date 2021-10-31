using System.Collections.Generic;

namespace Online_Shop.Models.DTO
{
    public class OrderProductsPromotions
    {
        public Order Order { get; set; }

        public List<PromotionDesc> Promotions { get; set; }

        public List<Order_Product> Order_Products { get; set; }
    }
}