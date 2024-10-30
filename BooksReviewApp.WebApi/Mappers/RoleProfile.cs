using AutoMapper;
using BooksReviewApp.Services.AspNet.Identity.Entities;
using BooksReviewApp.WebApi.Dtos.Permission;
using BooksReviewApp.WebApi.Dtos.Role;

namespace BooksReviewApp.WebApi.Mappers
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, ReadRoleDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RolePermissions, opt => opt.MapFrom(src => src.RolePermissions));

            CreateMap<RolePermission, PermissionDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PermissionId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Permission.Name));
        }
    }
}
