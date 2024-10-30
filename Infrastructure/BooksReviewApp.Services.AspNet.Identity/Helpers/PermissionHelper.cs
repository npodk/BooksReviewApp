using BooksReviewApp.Services.AspNet.Identity.Enums;

namespace BooksReviewApp.Services.AspNet.Identity.Helpers
{
    public static class PermissionHelper
    {
        public static IEnumerable<string> GeneratePermissionsForController(string controllerName)
        {
            foreach (var action in Enum.GetNames(typeof(PermissionAction)))
            {
                yield return $"{controllerName}.{action}";
            }
        }

        public static IEnumerable<string> GenerateAllPermissions()
        {
            var controllers = new List<string> { "Authors", "Books", "Favorites", "Genres", "Reviews", "Roles", "Users" };

            foreach (var controller in controllers)
            {
                foreach (var permission in GeneratePermissionsForController(controller))
                {
                    yield return permission;
                }
            }
        }
    }
}
