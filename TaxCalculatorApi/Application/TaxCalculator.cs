using TaxCalculatorApi.Application.Services.Interfaces;
using TaxCalculatorApi.DAL.Interfaces;
using TaxCalculatorApi.Repository;
using TaxCalculatorApi.Repository.Entity;

namespace TaxCalculatorApi.Application
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly ITaxBandCacheRepository _taxBandCacheRepository;

        public TaxCalculator(ITaxBandCacheRepository taxBandCacheRepository)
        {
            _taxBandCacheRepository = taxBandCacheRepository;
        }

        public int CalculateTotalTax(int income)
        {
            if (income < 0)
                throw new ArgumentException("Income should be more or equal zero.");

            int totalTax = 0;
            int previousLimit = 0;

            var taxBands = _taxBandCacheRepository.GetTaxBands();

            foreach (TaxBand taxband in taxBands)
            {
                if (income > taxband.LowerLimit)
                {
                    var taxableIncomeInBand = Math.Min(income, taxband.UpperLimit ?? int.MaxValue) - previousLimit;
                    totalTax += taxableIncomeInBand * taxband.Rate / 100;
                }
                previousLimit = taxband.UpperLimit ?? int.MaxValue;
            }

            return totalTax;
        }
    }
}
