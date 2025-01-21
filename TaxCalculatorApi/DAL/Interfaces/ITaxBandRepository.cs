using TaxCalculatorApi.Repository.Entity;

namespace TaxCalculatorApi.Repository.Interfaces
{
    public interface ITaxBandRepository
    {
        IEnumerable<TaxBand> GetOrderedListByLowerLimit();
    }
}
