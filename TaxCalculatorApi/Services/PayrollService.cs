using TaxCalculatorApi.Domain.Entities;
using TaxCalculatorApi.Dtos;
using TaxCalculatorApi.Exceptions;
using TaxCalculatorApi.Services.Interfaces;

namespace TaxCalculatorApi.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly ITaxService _taxService;
        public PayrollService(ITaxService taxService)
        {
            _taxService = taxService;
        }
        public PayrollDto GetPayrollInfo(int grossAnnualSalary)
        {
            if (grossAnnualSalary < 0)
                throw new InvalidAnnualSalaryException("Gross annual salary could not be less than 0.");

            var totalTax = _taxService.CalculateTotalTax(grossAnnualSalary);
            Payroll payroll = new Payroll(grossAnnualSalary, totalTax);
            return new PayrollDto(payroll);
        }
    }
}
