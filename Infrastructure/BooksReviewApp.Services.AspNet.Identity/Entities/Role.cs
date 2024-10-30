using Microsoft.AspNetCore.Identity;

namespace BooksReviewApp.Services.AspNet.Identity.Entities
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
