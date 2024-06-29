using AutoMapper;
using BooksReviewApp.Domain.Core.Entities;
using BooksReviewApp.WebApi.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReviewApp.WebApi.Mappers.UserProfiles
{
    public class UpdateUserMapperProfile : Profile
    {
        public UpdateUserMapperProfile()
        {
            CreateMap<PatchUserDto, User>();
        }
    }
}
