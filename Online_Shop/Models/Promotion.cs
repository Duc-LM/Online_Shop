namespace Online_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Promotion")]
    public partial class Promotion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promotion()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Short_desc { get; set; }

        [Required]
        [Display(Name = "Begin Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime Begin_date { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime End_date { get; set; }
        [Range(0, 100)]
        [Display(Name = "Discount(%)")]
        public int Percent_discount { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 0")]
        [Display(Name = "Quantity")]
        public int Quantity_left { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
