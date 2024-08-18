using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Author;

namespace BooksReviewApp.WebApi.Validators.AuthorValidators
{
    public class CreateAuthorDtoValidator : BaseAuthorDtoValidator<CreateAuthorDto>
    {
        public CreateAuthorDtoValidator(ILocalizationService localizationService) : base(localizationService)
        {
        }
    }
}
