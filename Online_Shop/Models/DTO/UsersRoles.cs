using System.Collections.Generic;
using PagedList;
namespace Online_Shop.Models.DTO
{
    public class UsersRoles
    {
        public IPagedList<User> Users { get; set; }
        public List<Role> Roles { get; set; }
    }
}