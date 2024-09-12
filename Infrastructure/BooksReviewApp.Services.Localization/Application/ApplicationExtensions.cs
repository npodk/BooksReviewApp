using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using BooksReviewApp.Core.Services.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksReviewApp.Services.Localization.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddCustomLocalization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<LocalizationOptions>()
                .Bind(configuration.GetSection(LocalizationOptions.SectionName))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.Configure<ValidationMessages>(configuration.GetSection("ValidationMessages"));

            services.AddSingleton<ILocalizationService, LocalizationService>();

            return services;
        }

        public static IConfigurationBuilder AddLocalizationConfiguration(this IConfigurationBuilder builder, IConfiguration configuration)
        {
            var localizationSection = configuration.GetSection(LocalizationOptions.SectionName);

            var validationMessagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, localizationSection.GetValue<string>("ValidationMessagesPath"));

            builder.AddJsonFile(validationMessagesPath, optional: false, reloadOnChange: true);

            return builder;
        }
    }
}
