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
        [StringLength(255)]
        public string Phone_number { get; set; }

        [Required]
        [StringLength(255)]
        public string Place_of_receipt { get; set; }


        [StringLength(255)]
        public string Note { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Payment Method")]
        public string Payment_method { get; set; }

        [Display(Name = "Total Price")]
        public decimal Total_Price { get; set; }


        [StringLength(255)]
        public string Status { get; set; }


        public decimal Ship_price { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Created_date { get; set; }


        public int? Promotion_id { get; set; }

        public virtual Promotion Promotion { get; set; }
        public int? User_id { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Product> Order_Product { get; set; }

        public virtual User User { get; set; }
    }
}
