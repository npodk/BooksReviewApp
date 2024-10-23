using BooksReviewApp.Services.AspNet.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using static BooksReviewApp.Domain.Constants.Constants;

namespace BooksReviewApp.Services.AspNet.Identity.Extensions
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

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AspIdentityDbContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
