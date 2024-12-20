﻿using AutoMapper;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Identity.WebApi.Dtos.Account;

namespace Identity.WebApi.Mappers
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<RegisterDto, ApplicationUser>();

            CreateMap<UpdateAccountDto, ApplicationUser>();

            CreateMap<PatchAccountDto, ApplicationUser>();

            CreateMap<ChangePasswordDto, ChangePasswordModel>();

            CreateMap<PatchAccountDto,  PatchAccountModel>();
        }
    }
}
