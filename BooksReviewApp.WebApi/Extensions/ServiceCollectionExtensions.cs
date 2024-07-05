using BooksReviewApp.WebApi.Handlers;
using BooksReviewApp.WebApi.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

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
    }
}
