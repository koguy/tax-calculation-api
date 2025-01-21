using Microsoft.Extensions.Caching.Memory;
using TaxCalculatorApi.Repository.Interfaces;

namespace TaxCalculatorApi.Repository
{
    public class CacheProvider : ICacheProvider
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<CacheProvider> _logger;
        public CacheProvider(IMemoryCache memoryCache, ILogger<CacheProvider> logger)
        {
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public bool TryGetValue<T>(string key, out T? item)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("The 'key' should not be null or empty.");

            try
            {
                var result = _memoryCache.TryGetValue(key, out item);

                if (result)
                    _logger.LogInformation($"Data by the {key} key was found in cache.");
                else
                    _logger.LogInformation($"Data by the {key} key was not found in cache.");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception has been occured during getting data from cache by {key} key.");
                throw;
            }
        }

        public void RemoveValue(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("The 'key' should not be null or empty.");

            try
            {
                _memoryCache.Remove(key);
                _logger.LogInformation($"Data by the {key} key have been removed from cache.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception has been occured during removing data from cache by {key} key.");
                throw;
            }
        }

        public void SetValue<T>(string key, T value, MemoryCacheEntryOptions options)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("The 'key' should not be null or empty.");

            try
            {
                _memoryCache.Set(key, value, options);
                _logger.LogInformation($"Data by the {key} key have been added to the cache.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception has been occured during getting data from cache by {key} key.");
                throw;
            }
        }
    }
}
