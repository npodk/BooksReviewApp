using AutoMapper;
using Identity.Domain.Entities;
using Identity.WebApi.Dtos.Permission;

namespace Identity.WebApi.Mappers
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<PermissionDto, Permission>();

            CreateMap<Permission, PermissionDto>();

        }
    }
}
