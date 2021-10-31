using System.Collections.Generic;

namespace Online_Shop.Models.DTO
{
    public class OrderPromotions
    {
        public Order Order { get; set; }
        public List<PromotionDesc> Promotions { get; set; }
    }
}