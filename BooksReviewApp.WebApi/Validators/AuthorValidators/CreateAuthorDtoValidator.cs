using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Author;

namespace BooksReviewApp.WebApi.Validators.AuthorValidators
{
    public class CreateBookDtoValidator : BaseAuthorDtoValidator<CreateAuthorDto>
    {
        public CreateBookDtoValidator(ILocalizationService localizationService) : base(localizationService)
        {
        }
    }
}
