namespace Online_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int id { get; set; }

        public int cart_id { get; set; }

        [Required]
        [StringLength(255)]
        public string customer_name { get; set; }

        [Required]
        [StringLength(50)]
        public string phone_number { get; set; }

        [Required]
        [StringLength(255)]
        public string place_of_receipt { get; set; }

        [Required]
        [StringLength(255)]
        public string note { get; set; }

        [Required]
        [StringLength(100)]
        public string payment_method { get; set; }

        public decimal total_price { get; set; }

        public int delivery_status_id { get; set; }

        public int is_paid { get; set; }

        public decimal ship_price { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_date { get; set; }

        public int? creator_id { get; set; }

        public virtual Delivery_status Delivery_status { get; set; }

        public virtual Order_Product Order_Product { get; set; }

        public virtual User User { get; set; }
    }
}
