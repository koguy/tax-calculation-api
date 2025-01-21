using TaxCalculatorApi.Repository.Entity;
using TaxCalculatorApi.Repository.Interfaces;

namespace TaxCalculatorApi.Repository
{
    public class TaxBandRepository : ITaxBandRepository
    {
        private readonly ITaxDbContext _dbContext;
        private readonly ILogger<TaxBandRepository> _logger;
        public TaxBandRepository(ITaxDbContext dbContext, ILogger<TaxBandRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IEnumerable<TaxBand> GetOrderedListByLowerLimit()
        {
            try
            {
                return _dbContext.TaxBands.OrderBy(tb => tb.LowerLimit).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured during the getting list of tax band.");
                throw;
            }
        }
    }
}
