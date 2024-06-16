using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Domain.Core.Entities;

namespace BooksReviewApp.Services.EF.Interfaces
{
    public interface IUserDbService : ICrudService<User>
    {
    }
}
