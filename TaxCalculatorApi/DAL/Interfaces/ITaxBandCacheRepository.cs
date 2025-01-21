using TaxCalculatorApi.Repository.Entity;

namespace TaxCalculatorApi.DAL.Interfaces
{
    public interface ITaxBandCacheRepository
    {
        IEnumerable<TaxBand> GetTaxBands();
    }
}
