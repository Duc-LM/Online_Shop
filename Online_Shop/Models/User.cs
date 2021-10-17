namespace Online_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Order_Product = new HashSet<Order_Product>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "User name")]

        public string User_name { get; set; }


        [StringLength(255)]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$",
           ErrorMessage = "Password: at least one lower case letter, one upper case letter, special character, one number and at least 8 characters length")]
        public string Password { get; set; }

        [NotMapped]
        [StringLength(255)]
        [Display(Name = "Confirm Password")]
        //[Compare("Password", ErrorMessage = "Password and ReEnter Password do not match")]
        public string RePassword { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }


        public string Avatar { get; set; }

        [Required]
        [StringLength(100)]
        public string Gender { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9]*$",
            ErrorMessage = "This number is invalid")]
        public string Phone_number { get; set; }

        [Display(Name = "Role Id")]
        public int? Role_id { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Dob { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Product> Order_Product { get; set; }

        public virtual Role Role { get; set; }
    }
}
