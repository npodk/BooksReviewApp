using BooksReviewApp.Core.Domain.Interfaces;

namespace BooksReviewApp.WebApi.Dtos.User
{
    public class UpdateUserDto : BaseUserDto, IModel
    {
        public Guid Id { get; set; }
    }
}
