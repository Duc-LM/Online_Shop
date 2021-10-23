namespace Online_Shop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Spec")]
    public partial class Spec
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string CPU { get; set; }

        [Required]
        [StringLength(255)]
        public string GPU { get; set; }

        [Required]
        [StringLength(255)]
        public string Screen { get; set; }

        [Required]
        [StringLength(255)]
        public string Ports { get; set; }

        [Required]
        [StringLength(255)]
        public string RAM { get; set; }

        [Required]
        [StringLength(255)]
        public string Storage { get; set; }

        [Required]
        [StringLength(255)]
        public string Connectivity { get; set; }

        [Required]
        [StringLength(255)]
        public string Size { get; set; }

        [Required]
        [StringLength(255)]
        public string Weight { get; set; }

        [Required]
        [StringLength(255)]
        public string Battery { get; set; }

        [Required]
        [StringLength(255)]
        public string Manufacturer { get; set; }

        public int? Product_id { get; set; }

        public virtual Product Product { get; set; }
    }
}
