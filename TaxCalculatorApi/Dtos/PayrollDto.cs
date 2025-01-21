using TaxCalculatorApi.Domain.Entities;

namespace TaxCalculatorApi.Dtos
{
    public class PayrollDto
    {
        public PayrollDto(Payroll payroll)
        {
            GrossAnnualSalary = payroll.GrossAnnualSalary;
            GrossMonthlySalary = payroll.GrossMonthlySalary;
            NetAnnualSalary = payroll.NetAnnualSalary;
            NetMonthlySalary = payroll.NetMonthlySalary;
            AnnualTaxPaid = payroll.AnnualTaxPaid;
            MonthlyTaxPaid = payroll.MonthlyTaxPaid;
        }
        public float GrossAnnualSalary { get; set; }
        public float GrossMonthlySalary { get; set; }
        public float NetAnnualSalary { get; set; }
        public float NetMonthlySalary { get; set; }
        public float AnnualTaxPaid { get; set; }
        public float MonthlyTaxPaid { get; set; }
    }
}
