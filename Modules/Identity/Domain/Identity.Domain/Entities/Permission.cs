using BooksReviewApp.Core.Domain.Interfaces;

namespace Identity.Domain.Entities
{
    public class Permission : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
