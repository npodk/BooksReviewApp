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
            // Add other services here
        }
    }
}
