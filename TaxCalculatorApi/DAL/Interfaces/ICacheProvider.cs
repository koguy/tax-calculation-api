using Microsoft.Extensions.Caching.Memory;

namespace TaxCalculatorApi.Repository.Interfaces
{
    public interface ICacheProvider
    {
        bool TryGetValue<T>(string key, out T? item);
        void SetValue<T>(string key, T value, MemoryCacheEntryOptions options);
        void RemoveValue(string key);
    }
}
