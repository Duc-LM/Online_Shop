using System.ComponentModel.DataAnnotations;

namespace Online_Shop.Models.DTO
{
    public class Password
    {

        //public int UserId { get; set; }
        //public string UserName { get; set; }
        //public string CurrentPassword { get; set; }

        //[Required]
        //[Display(Name = "Current Password")]
        //[RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$",
        //   ErrorMessage = "Password: at least one lower case letter, one upper case letter, special character, one number and at least 8 characters length")]
        //public string CurrentPasswordInput { get; set; }



        [Required]
        [StringLength(255)]
        [Display(Name = "New Password")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$",
           ErrorMessage = "Password: at least one lower case letter, one upper case letter, special character, one number and at least 8 characters length")]
        public string NewPassword { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirm Password do not match")]
        public string ReNewPassword { get; set; }
    }
}