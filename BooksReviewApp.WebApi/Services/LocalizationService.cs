using BooksReviewApp.WebApi.Interfaces;
using BooksReviewApp.WebApi.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Text.Json;
using static BooksReviewApp.WebApi.Constants.Constants;

namespace BooksReviewApp.WebApi.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IMemoryCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<LocalizationService> _logger;
        private readonly Localization _options;

        private Dictionary<string, Dictionary<string, string>> _messages;
        private TimeSpan CacheDuration { get; set; } = TimeSpan.FromHours(1);

        public LocalizationService(
            IMemoryCache cache,
            IHttpContextAccessor httpContextAccessor,
            ILogger<LocalizationService> logger,
            IOptions<Localization> localizationOptions)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _options = localizationOptions.Value;
            _messages = new Dictionary<string, Dictionary<string, string>>();
        }

        public string GetValidationMessage(string key, params object[] args)
        {
            var culture = _httpContextAccessor.HttpContext?.Request.Query["culture"];

            if (string.IsNullOrEmpty(culture))
                culture = _options.DefaultCulture;

            var messages = LoadMessages();

            if (messages.TryGetValue(culture, out var cultureMessages) && cultureMessages.TryGetValue(key, out var message))
            {
                return string.Format(CultureInfo.CurrentCulture, message, args);
            }

            _logger.LogWarning("Validation message for key '{Key}' not found in culture '{Culture}'.", key, culture);
            return key;
        }

        private Dictionary<string, Dictionary<string, string>> LoadMessages()
        {
            if (_cache.TryGetValue(CacheKeys.ValidationMessagesLocalized, out Dictionary<string, Dictionary<string, string>> cachedMessages))
            {
                return cachedMessages;
            }

            if (_messages.Count != 0)
            {
                return _messages;
            }

            try
            {
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _options.ValidationMessagesPath);
                var json = File.ReadAllText(filePath);
                _messages = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json)
                    ?? new Dictionary<string, Dictionary<string, string>>();
                _cache.Set(CacheKeys.ValidationMessagesLocalized, _messages, CacheDuration);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading validation messages from file.");
            }

            return _messages;
        }
    }
}
