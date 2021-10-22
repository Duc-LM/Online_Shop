namespace Online_Shop.Models
{
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
            Specs = new HashSet<Spec>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public string Images { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "The value entered must be greater than or equal to 0 ")]
        public decimal Price { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "The value entered must be greater than or equal to 0 ")]
        public int Quantity { get; set; }

        [Required]
        public string Short_desc { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Created At")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Created_at { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Updated At")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Updated_at { get; set; }

        [Display(Name = "Role")]
        public int? Category_id { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Product> Order_Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Spec> Specs { get; set; }
    }
}
