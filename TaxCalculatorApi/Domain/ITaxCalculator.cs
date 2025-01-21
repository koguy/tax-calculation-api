namespace TaxCalculatorApi.Domain
{
    public interface ITaxCalculator
    {
        int CalculateTotalTax(int income);
    }
}
