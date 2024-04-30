using Common.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // one-to-many relationship
        public ICollection<IFavorite> Favorites { get; set; } = new List<IFavorite>();

        public ICollection<IReview> Reviews { get; set; } = new List<IReview>();

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
