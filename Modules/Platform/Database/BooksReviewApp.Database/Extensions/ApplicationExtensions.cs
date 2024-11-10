using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using static BooksReviewApp.Domain.Constants;

namespace BooksReviewApp.Database.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<LibraryDbContext>(options =>
                options.UseNpgsql(connectionString,
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, SchemaTypes.Dbo)));

            return services;
        }
    }
}
