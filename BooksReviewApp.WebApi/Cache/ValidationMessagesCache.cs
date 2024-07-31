using BooksReviewApp.WebApi.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using static BooksReviewApp.WebApi.Constants.Constants;

namespace BooksReviewApp.WebApi.Cache
{
    public class ValidationMessagesCache : IValidationMessagesCache, IDisposable
    {
        private readonly TimeSpan _cacheDuration = TimeSpan.FromHours(1);
        private readonly IMemoryCache _cache;
        private readonly ILogger<ValidationMessagesCache> _logger;

        private readonly Localization _options;
        private readonly FileSystemWatcher _fileWatcher;
        private readonly Timer _debounceTimer;
        private readonly int _debouncePeriod = 5000;
        private bool _disposed;

        public ValidationMessagesCache(
            IMemoryCache cache,
            ILogger<ValidationMessagesCache> logger,
            IOptions<Localization> localizationOptions)
        {
            _cache = cache;
            _logger = logger;
            _options = localizationOptions.Value;

            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _options.ValidationMessagesPath);
            _fileWatcher = CreateFileWatcher(filePath);
            _debounceTimer = new Timer(DebounceTimerCallback, null, Timeout.Infinite, Timeout.Infinite);
            LoadMessages();
        }

        public Dictionary<string, Dictionary<string, string>> GetMessages() => LoadMessages();

        private FileSystemWatcher CreateFileWatcher(string filePath)
        {
            var watcher = new FileSystemWatcher(Path.GetDirectoryName(filePath) ?? string.Empty, Path.GetFileName(filePath))
            {
                NotifyFilter = NotifyFilters.LastWrite
            };

            watcher.Changed += OnFileChanged;
            watcher.EnableRaisingEvents = true;

            return watcher;
        }

        private Dictionary<string, Dictionary<string, string>> LoadMessages()
        {
            if (_cache.TryGetValue(CacheKeys.ValidationMessagesLocalized, out Dictionary<string, Dictionary<string, string>>? cachedMessages))
            {
                return cachedMessages ?? new Dictionary<string, Dictionary<string, string>>();
            }

            try
            {
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _options.ValidationMessagesPath);
                var json = File.ReadAllText(filePath);
                var messages = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json)
                    ?? new Dictionary<string, Dictionary<string, string>>();
                _cache.Set(CacheKeys.ValidationMessagesLocalized, messages, _cacheDuration);
                return messages;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading validation messages from file.");
                return new Dictionary<string, Dictionary<string, string>>();
            }
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                _debounceTimer.Change(_debouncePeriod, Timeout.Infinite);
            }
        }

        private void DebounceTimerCallback(object state)
        {
            _logger.LogInformation("Validation messages file changed. Reloading messages.");
            InvalidateCache();
        }

        private void InvalidateCache()
        {
            _cache.Remove(CacheKeys.ValidationMessagesLocalized);
            LoadMessages();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _fileWatcher?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
