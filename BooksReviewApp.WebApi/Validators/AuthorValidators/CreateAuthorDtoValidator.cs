using BooksReviewApp.WebApi.Dtos.Author;
using BooksReviewApp.WebApi.Services;

namespace BooksReviewApp.WebApi.Validators.AuthorValidators
{
    public class CreateAuthorDtoValidator : BaseAuthorDtoValidator<CreateAuthorDto>
    {
        public CreateAuthorDtoValidator(ILocalizationService localizationService) : base(localizationService)
        {
        }
    }
}
