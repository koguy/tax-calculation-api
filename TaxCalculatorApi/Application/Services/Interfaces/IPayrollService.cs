using TaxCalculatorApi.Dtos;

namespace TaxCalculatorApi.Application.Services.Interfaces
{
    public interface IPayrollService
    {
        PayrollDto GetPayrollInfo(int grossAnnualSalary);
    }
}
