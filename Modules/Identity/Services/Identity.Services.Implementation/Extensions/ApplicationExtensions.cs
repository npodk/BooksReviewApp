using BooksReviewApp.Services.Contracts.Interfaces.Identity;
using BooksReviewApp.Services.Implementation.Identity;
using Identity.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Services.Implementation.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddIdentityServices(this IServiceCollection services)
        {
            services.AddScoped<IIntegrationService, IntegrationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IGuardService, GuardService>();
        }
    }
}
