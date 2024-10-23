using AutoMapper;
using BooksReviewApp.Services.AspNet.Identity.Models;
using BooksReviewApp.WebApi.Dtos.Account;

namespace BooksReviewApp.WebApi.Mappers
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<RegisterDto, ApplicationUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
