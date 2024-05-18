using BooksReviewApp.Core.Domain.Interfaces;
using BooksReviewApp.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Services.Database
{
    public class BaseDbService<T> : IService where T : IModel
    {
    }
}
