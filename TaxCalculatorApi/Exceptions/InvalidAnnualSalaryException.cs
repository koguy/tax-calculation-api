namespace TaxCalculatorApi.Exceptions
{
    public class InvalidAnnualSalaryException : Exception
    {
        public InvalidAnnualSalaryException() :base() { }
        public InvalidAnnualSalaryException(string message) : base(message) { }
        public InvalidAnnualSalaryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
