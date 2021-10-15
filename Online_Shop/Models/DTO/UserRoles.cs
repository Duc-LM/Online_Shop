using System.Collections.Generic;

namespace Online_Shop.Models.DTO
{
    public class UserRoles
    {
        public User User { get; set; }
        public List<Role> Roles { get; set; }
    }
}