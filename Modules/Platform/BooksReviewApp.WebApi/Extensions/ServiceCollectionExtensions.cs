using BooksReviewApp.WebApi.Handlers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Reflection;

namespace BooksReviewApp.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExceptionHandlers(this IServiceCollection services)
        {
            services.AddTransient<NpgsqlExceptionHandler>();
            services.AddTransient<ValidationExceptionHandler>();

            services.AddSingleton(provider =>
            {
                var handlers = new Dictionary<Type, IExceptionHandler>
                {
                    { typeof(NpgsqlException), provider.GetRequiredService<NpgsqlExceptionHandler>() },
                    { typeof(ValidationException), provider.GetRequiredService<ValidationExceptionHandler>() }
                };
                return handlers;
            });

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddFluentValidationAutoValidation()
                    .AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
