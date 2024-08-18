using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using BooksReviewApp.Core.Services.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace BooksReviewApp.Services.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<LocalizationService> _logger;
        private readonly LocalizationOptions _options;
        private readonly IOptionsMonitor<ValidationMessages> _validationMessagesMonitor;

        public LocalizationService(
            IHttpContextAccessor httpContextAccessor,
            ILogger<LocalizationService> logger,
            IOptions<LocalizationOptions> localizationOptions,
            IOptionsMonitor<ValidationMessages> validationMessagesMonitor)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _options = localizationOptions.Value;
            _validationMessagesMonitor = validationMessagesMonitor;
        }

        public string GetValidationMessage(string key, params object[] args)
        {
            var culture = _httpContextAccessor.HttpContext?.Request.Query["culture"].ToString();

            if (string.IsNullOrEmpty(culture))
                culture = _options.DefaultCulture;

            if (_validationMessagesMonitor.CurrentValue.TryGetValue(culture, out var cultureMessages)
                && cultureMessages.TryGetValue(key, out var message))
            {
                return string.Format(CultureInfo.CurrentCulture, message, args);
            }

            _logger.LogWarning("Validation message for key '{Key}' not found in culture '{Culture}'.", key, culture);
            return key;
        }
    }
}
