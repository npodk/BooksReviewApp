using BooksReviewApp.WebApi.Cache;
using BooksReviewApp.WebApi.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace BooksReviewApp.WebApi.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<LocalizationService> _logger;
        private readonly Localization _options;
        private readonly IValidationMessagesCache _validationMessagesCache;

        public LocalizationService(
            IHttpContextAccessor httpContextAccessor,
            ILogger<LocalizationService> logger,
            IOptions<Localization> localizationOptions,
            IValidationMessagesCache validationMessagesCache)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _options = localizationOptions.Value;
            _validationMessagesCache = validationMessagesCache;
        }

        public string GetValidationMessage(string key, params object[] args)
        {
            var culture = _httpContextAccessor.HttpContext?.Request.Query["culture"].ToString();

            if (string.IsNullOrEmpty(culture))
                culture = _options.DefaultCulture;

            var messages = _validationMessagesCache.GetMessages();

            if (messages.TryGetValue(culture, out var cultureMessages) && cultureMessages.TryGetValue(key, out var message))
            {
                return string.Format(CultureInfo.CurrentCulture, message, args);
            }

            _logger.LogWarning("Validation message for key '{Key}' not found in culture '{Culture}'.", key, culture);
            return key;
        }
    }
}
