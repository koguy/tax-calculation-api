using TaxCalculatorApi.Application.Services.Interfaces;

namespace TaxCalculatorApi.Application.Services
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
