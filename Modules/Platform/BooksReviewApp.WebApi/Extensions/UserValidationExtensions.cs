﻿using BooksReviewApp.Core.Services.Interfaces;
using FluentValidation;
using static BooksReviewApp.WebApi.Constants;

namespace BooksReviewApp.WebApi.Extensions
{
    public static class UserValidationExtensions
    {
        public static IRuleBuilder<T, string> ApplyUsernameRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(UserValidation.MaxUsernameLength)
                .WithMessage(localizationService.GetValidationMessage("UsernameMaxLength", UserValidation.MaxUsernameLength));
        }

        public static IRuleBuilder<T, string> ApplyEmailRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(UserValidation.MaxEmailLength)
                .WithMessage(localizationService.GetValidationMessage("EmailMaxLength", UserValidation.MaxEmailLength))
                .EmailAddress()
                .WithMessage(localizationService.GetValidationMessage("InvalidEmailFormat"));
        }
    }
}
