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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_Product = new HashSet<Order_Product>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Customer_name { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone_number { get; set; }

        [Required]
        [StringLength(255)]
        public string Place_of_receipt { get; set; }

        [Required]
        [StringLength(255)]
        public string Note { get; set; }

        [Required]
        [StringLength(100)]
        public string Payment_method { get; set; }

        public decimal Total_price { get; set; }

        [Required]
        [StringLength(255)]
        public string Delivery_status { get; set; }

        public int Is_paid { get; set; }

        public decimal Ship_price { get; set; }

        [Column(TypeName = "date")]
        public DateTime Created_date { get; set; }

        public int Is_customer { get; set; }

        public int? Promotion_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Product> Order_Product { get; set; }

        public virtual Promotion Promotion { get; set; }

        public virtual Promotion Promotion1 { get; set; }
    }
}
