namespace Online_Shop.Models
{
    using Online_Shop.Validators;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Order_Product = new HashSet<Order_Product>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        [ProductNotExist]
        public string name { get; set; }

        [Required]
        public string short_desc { get; set; }

        [Required]
        [StringLength(255)]
        public string images { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        [ProductCategoryNotNull]
        public int? category_id { get; set; }

        [Required]
        [StringLength(255)]
        public string cpu { get; set; }

        [Required]
        [StringLength(255)]
        public string gpu { get; set; }

        [Required]
        [StringLength(255)]
        public string screen { get; set; }

        [Required]
        [StringLength(255)]
        public string storage { get; set; }

        [Required]
        [StringLength(255)]
        public string ram { get; set; }

        [Required]
        [StringLength(255)]
        public string os { get; set; }

        [Required]
        [StringLength(255)]
        public string size { get; set; }

        [Required]
        [StringLength(255)]
        public string weight { get; set; }

        [Required]
        [StringLength(255)]
        public string ports { get; set; }

        [Required]
        [StringLength(255)]
        public string connectivity { get; set; }

        [Required]
        [StringLength(255)]
        public string battery { get; set; }

        [Required]
        [StringLength(255)]
        public string extras { get; set; }

        [Required]
        [StringLength(255)]
        public string manufacturer { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime MFG { get; set; }
        [Required]
        public int quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        [Column(TypeName = "date")]
        public DateTime updated_at { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Product> Order_Product { get; set; }
    }
}
