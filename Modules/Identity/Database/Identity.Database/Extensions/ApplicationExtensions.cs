using BooksReviewApp.Services.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using static BooksReviewApp.Services.AspNet.Identity.Constants;

namespace Identity.Database.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddIdentityDbContext(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<AspIdentityDbContext>(options =>
                options.UseNpgsql(connectionString,
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, SchemaTypes.Identity)));

            return services;
        }
    }
}
