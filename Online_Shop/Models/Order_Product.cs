namespace Online_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order_Product()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public int? Order_id { get; set; }

        public int Product_id { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime Created_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual Product Product { get; set; }
    }
}
