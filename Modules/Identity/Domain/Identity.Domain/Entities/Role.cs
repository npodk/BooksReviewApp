using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public Role() : base() { }

        public Role(string roleName) : base()
        {
            Name = roleName;
        }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
