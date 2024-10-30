using AutoMapper;
using BooksReviewApp.Services.AspNet.Identity.Entities;
using BooksReviewApp.WebApi.Dtos.Permission;

namespace BooksReviewApp.WebApi.Mappers
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
