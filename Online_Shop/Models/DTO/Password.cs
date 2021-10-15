using System.ComponentModel.DataAnnotations;

namespace Online_Shop.Models.DTO
{
    public class Password
    {

        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        [Required]
        public string CurrentPasswordInput { get; set; }
        [Required]
        [StringLength(255)]
        public string NewPassword { get; set; }
        [Required]
        [StringLength(255)]
        public string ReNewPassword { get; set; }
    }
}