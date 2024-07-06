using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;

namespace BooksReviewApp.WebApi.Middlewares
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>() != null)
            {
                var actionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
                var actionContext = new ActionContext(context, context.GetRouteData(), actionDescriptor ?? new ControllerActionDescriptor());
                if (!actionContext.ModelState.IsValid)
                {
                    var failures = new List<ValidationFailure>();
                    foreach (var state in actionContext.ModelState)
                    {
                        if (state.Value?.Errors != null)
                        {
                            failures.AddRange(state.Value.Errors.Select(error => new ValidationFailure(state.Key, error.ErrorMessage)));
                        }
                    }

                    if (failures.Any())
                    {
                        throw new ValidationException(failures);
                    }
                }
            }

            await _next(context);
        }
    }
}
