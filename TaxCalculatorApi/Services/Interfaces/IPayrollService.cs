using TaxCalculatorApi.Dtos;

namespace TaxCalculatorApi.Services.Interfaces
{
    public interface IPayrollService
    {
        PayrollDto GetPayrollInfo(int grossAnnualSalary);
    }
}
