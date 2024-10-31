using AutoMapper;
using BooksReviewApp.Services.AspNet.Identity.Entities;
using BooksReviewApp.WebApi.Dtos.Permission;

namespace BooksReviewApp.WebApi.Converters.RoleConverters
{
    public class RolePermissionsConverter : IValueConverter<ICollection<RolePermission>, ICollection<PermissionDto>>
    {
        public ICollection<PermissionDto> Convert(ICollection<RolePermission> sourceMember, ResolutionContext context)
        {
            return sourceMember.Select(rp => new PermissionDto
            {
                Id = rp.PermissionId,
                Name = rp.Permission.Name 
            }).ToList();
        }
    }
}
