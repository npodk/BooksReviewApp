using AutoMapper;
using Identity.Domain.Entities;
using Identity.WebApi.Dtos.Permission;

namespace Identity.WebApi.Converters
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
