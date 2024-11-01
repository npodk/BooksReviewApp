using AutoMapper;
using Identity.Domain.Entities;
using Identity.WebApi.Dtos.Account;

namespace Identity.WebApi.Mappers
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
