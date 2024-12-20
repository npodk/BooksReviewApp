﻿using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class PatchUserDtoValidator : BaseValidator<PatchUserDto>
    {
        public PatchUserDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Username)
                .NotNull().When(dto => dto.Username != null)
                .ApplyUsernameRules(localizationService);

            RuleFor(dto => dto.Email)
                .NotNull().When(dto => dto.Email != null)
                .ApplyEmailRules(localizationService);
        }
    }
}
