using BooksReviewApp.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;

namespace BooksReviewApp.WebApi.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly string ResourcesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocalizationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string GetValidationMessage(string key, params object[] args)
        {
            var culture = new CultureInfo("en-us");
            var resourceFilePath = Path.Combine(ResourcesDirectory, "ValidationMessages.resx");
            var resourceManager = new ResourceManager(Path.GetFileNameWithoutExtension(resourceFilePath), Assembly.GetExecutingAssembly());

            var message = resourceManager.GetString(key, culture) ?? $"Key '{key}' not found in resources.";
            return string.Format(message, args);
        }

        private CultureInfo GetCurrentCulture()
        {
            try
            {
                var cultureQuery = _httpContextAccessor.HttpContext?.Request.Query["culture"];
                var cultureName = string.IsNullOrEmpty(cultureQuery) ? "en" : cultureQuery.ToString();
                return new CultureInfo(cultureName);
            }
            catch (CultureNotFoundException)
            {
                return CultureInfo.InvariantCulture;
            }
        }
    }
}
