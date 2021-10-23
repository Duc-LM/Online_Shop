namespace Online_Shop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Order_Product
    {
        public int Id { get; set; }

        public int? Order_id { get; set; }

        public int? Product_id { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime Created_at { get; set; }

        public int? User_id { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
