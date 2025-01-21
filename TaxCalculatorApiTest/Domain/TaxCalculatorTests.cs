using Moq;
using TaxCalculatorApi.DAL.Interfaces;
using TaxCalculatorApi.Domain;
using TaxCalculatorApi.Repository.Entity;

namespace TaxCalculatorApiTest.Domain
{
    public class TaxCalculatorTests
    {
        private List<TaxBand> _taxBands = new List<TaxBand>()
        {
            new TaxBand() { Id = 1, Name = "Tax band A", LowerLimit = 0, UpperLimit = 5000, Rate = 0 },
            new TaxBand() { Id = 2, Name = "Tax band B", LowerLimit = 5000, UpperLimit = 20000, Rate = 20 },
            new TaxBand() { Id = 3, Name = "Tax band C", LowerLimit = 20000, UpperLimit = null, Rate = 40 }
        };


        [Theory]
        [MemberData(nameof(Data))]
        public void CalculateTotalTax_ReturnCorrectValue(int income, int expectedTax)
        {
            // Arrange
            var mockTaxBandCacheRepository = new Mock<ITaxBandCacheRepository>();
            mockTaxBandCacheRepository.Setup(x => x.GetTaxBands()).Returns(_taxBands);
            var taxCalculator = new TaxCalculator(mockTaxBandCacheRepository.Object);

            // Act
            var result = taxCalculator.CalculateTotalTax(income);

            // Assert
            Assert.Equal(expectedTax, result);
        }

        [Fact]
        public void CalculateTotalTax_InvalidIncome_ThrowArgumentException()
        {
            // Arrange
            var mockTaxBandCacheRepository = new Mock<ITaxBandCacheRepository>();
            var taxCalculator = new TaxCalculator(mockTaxBandCacheRepository.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => taxCalculator.CalculateTotalTax(-1));
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { 0, 0 };
            yield return new object[] { 10000, 1000 };
            yield return new object[] { 40000, 11000 };
        }

    }
}
