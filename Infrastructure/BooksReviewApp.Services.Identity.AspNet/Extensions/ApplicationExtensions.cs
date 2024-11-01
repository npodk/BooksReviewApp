using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BooksReviewApp.Services.Identity.AspNet.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddCustomIdentity<TUser, TRole, TContext>(this IServiceCollection services)
            where TUser : class
            where TRole : class
            where TContext : DbContext
        {
            services.AddIdentity<TUser, TRole>(options =>
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
            .AddEntityFrameworkStores<TContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
