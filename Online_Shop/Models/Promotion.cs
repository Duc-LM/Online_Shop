namespace Online_Shop.Models
{
    using Online_Shop.Validators;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Promotion")]
    public partial class Promotion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promotion()
        {
            Orders = new HashSet<Order>();
            Orders1 = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [PromotionNotExist]
        public string Name { get; set; }

        [Required]
        public string Short_desc { get; set; }

        [PromotionValidateDate]
        [Column(TypeName = "date")]
        public DateTime Begin_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime End_date { get; set; }

        public int Percent_discount { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity_left { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders1 { get; set; }
    }
}
