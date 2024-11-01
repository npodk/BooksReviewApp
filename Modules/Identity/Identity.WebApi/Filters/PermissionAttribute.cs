using BooksReviewApp.Services.Contracts.Interfaces.Identity;
using Identity.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Identity.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class PermissionAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public string PermissionName { get; }

        public PermissionAttribute(string permissionName)
        {
            PermissionName = permissionName;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var guardService = context.HttpContext.RequestServices.GetService(typeof(IGuardService)) as IGuardService;

            var userId = context.HttpContext.User.GetUserId();

            if (!userId.HasValue)
            {
                context.Result = new ForbidResult();
                return;
            }

            if (guardService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                return;
            }

            if (!await guardService.UserHasPermissionAsync(userId.Value, PermissionName))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
