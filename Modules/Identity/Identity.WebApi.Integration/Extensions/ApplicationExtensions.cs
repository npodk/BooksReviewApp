using Microsoft.Extensions.DependencyInjection;

namespace Identity.WebApi.Integration.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddIdentityIntegrationServices(this IServiceCollection services)
        {
            //services.AddHttpClient();
            services.AddScoped<IIntegrationService, IntegrationService>();
        }
    }
}
