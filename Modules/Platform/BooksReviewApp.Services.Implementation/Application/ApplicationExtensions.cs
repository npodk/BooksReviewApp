using BooksReviewApp.Services.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BooksReviewApp.Services.Implementation.Application
{
    public static class ApplicationExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IUserApplicationService, UserApplicationService>();
            // Add other services here
        }
    }
}
