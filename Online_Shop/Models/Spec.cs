namespace Online_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Spec")]
    public partial class Spec
    {
        public int? Id { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string CPU { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string GPU { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string Screen { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string Ports { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string RAM { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(255)]
        public string Storage { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(255)]
        public string Connectivity { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(255)]
        public string Size { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(100)]
        public string Weight { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(100)]
        public string Battery { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(100)]
        public string Manufacturer { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Product_id { get; set; }

        public virtual Product Product { get; set; }
    }
}
