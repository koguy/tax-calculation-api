namespace TaxCalculatorApi.Application
{
    public interface ITaxService
    {
        int CalculateTotalTax(int income);
    }
}
