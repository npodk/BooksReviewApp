using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.User;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class UpdateUserDtoValidator : BaseUserDtoValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator(ILocalizationService localizationService) : base(localizationService)
        {
        }
    }
}
