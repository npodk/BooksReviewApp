using BooksReviewApp.Services.Identity.AspNet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
                var provider = services.BuildServiceProvider();
                var settings = provider.GetRequiredService<IOptions<IdentitySettings>>().Value;

                // Password settings
                options.Password.RequireDigit = settings.Password.RequireDigit;
                options.Password.RequireLowercase = settings.Password.RequireLowercase;
                options.Password.RequireNonAlphanumeric = settings.Password.RequireNonAlphanumeric;
                options.Password.RequireUppercase = settings.Password.RequireUppercase;
                options.Password.RequiredLength = settings.Password.RequiredLength;
                options.Password.RequiredUniqueChars = settings.Password.RequiredUniqueChars;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(settings.Lockout.DefaultLockoutTimeSpanInMinutes);
                options.Lockout.MaxFailedAccessAttempts = settings.Lockout.MaxFailedAccessAttempts;
                options.Lockout.AllowedForNewUsers = settings.Lockout.AllowedForNewUsers;

                // User settings
                options.User.RequireUniqueEmail = settings.User.RequireUniqueEmail;
            })
            .AddEntityFrameworkStores<TContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
