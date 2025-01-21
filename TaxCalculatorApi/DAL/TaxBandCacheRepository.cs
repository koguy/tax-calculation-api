using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using TaxCalculatorApi.Config;
using TaxCalculatorApi.DAL.Interfaces;
using TaxCalculatorApi.Repository;
using TaxCalculatorApi.Repository.Entity;
using TaxCalculatorApi.Repository.Interfaces;

namespace TaxCalculatorApi.DAL
{
    public class TaxBandCacheRepository : TaxBandRepository, ITaxBandCacheRepository
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly TaxBandCacheSettings _cacheSettings;
        private const string TAX_BANDS_CACHE_KEY = "taxBands";
        public TaxBandCacheRepository(ITaxDbContext dbContext, ILogger<TaxBandCacheRepository> logger, ICacheProvider cacheProvider, IOptions<TaxBandCacheSettings> options) 
            : base(dbContext, logger)
        {
            _cacheProvider = cacheProvider;
            _cacheSettings = options.Value;
        }

        public IEnumerable<TaxBand> GetTaxBands()
        {
            IEnumerable<TaxBand> taxBands = new List<TaxBand>();
            if (!_cacheProvider.TryGetValue(TAX_BANDS_CACHE_KEY, out taxBands))
            {
                taxBands = GetOrderedListByLowerLimit();
                var memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(_cacheSettings.SlidingExpirationMinute))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(_cacheSettings.AbsoluteExpirationMinute));

                _cacheProvider.SetValue(TAX_BANDS_CACHE_KEY, taxBands, memoryCacheEntryOptions);
            }
            return taxBands;
        }
    }
}
