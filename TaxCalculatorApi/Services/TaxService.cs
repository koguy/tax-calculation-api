using TaxCalculatorApi.Domain;
using TaxCalculatorApi.Services.Interfaces;

namespace TaxCalculatorApi.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxCalculator _taxCalculator;

        public TaxService(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public int CalculateTotalTax(int income)
        {
            return _taxCalculator.CalculateTotalTax(income);
        }
    }
}
