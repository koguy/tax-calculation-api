namespace TaxCalculatorApi.Domain.Entities

{
    public class Payroll
    {
        private const int MONTHS_IN_YEAR = 12;

        private readonly float _grossAnnualSalary;
        private readonly float _annualTaxPaid;
        public Payroll(float grossAnnualSalary, float annualTaxPaid)
        {
            if (grossAnnualSalary < 0)
                throw new ArgumentException("Gross annual salary should be more than 0");

            if (annualTaxPaid < 0)
                throw new ArgumentException("Annual tax paid should be more than 0");

            if (grossAnnualSalary < annualTaxPaid)
                throw new ArgumentException("Gross annual salary should be more than annual tax paid.");

            _grossAnnualSalary = grossAnnualSalary;
            _annualTaxPaid = annualTaxPaid;
        }

        public float GrossAnnualSalary => _grossAnnualSalary;
        public float GrossMonthlySalary => _grossAnnualSalary / MONTHS_IN_YEAR;
        public float NetAnnualSalary => _grossAnnualSalary - _annualTaxPaid;
        public float NetMonthlySalary => (_grossAnnualSalary - _annualTaxPaid) / MONTHS_IN_YEAR;
        public float AnnualTaxPaid => _annualTaxPaid;
        public float MonthlyTaxPaid => _annualTaxPaid / MONTHS_IN_YEAR;
    }
}
