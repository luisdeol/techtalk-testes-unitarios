using Moq;
using TechTalkDemo.UnitTests.Repositories;
using TechTalkDemo.UnitTests.Services;
using Xunit;

namespace TechTalkDemo.UnitTests
{
    public class TaxServiceTests
    {
        [Theory]
        [InlineData(7500, 1500)]
        [InlineData(15000, 4500)]
        [InlineData(3000, 300)]
        public void GrossSalariesOverZero_CalculatingTax_ReturnRightValue(double grossSalary, double expectedTax) {
            // Arrange
            var taxRepositoryMock = new Mock<ITaxRepository>();
            var taxService = new TaxService(taxRepositoryMock.Object);

            // Act
            var tax = taxService.CalculateTaxesFromGrossSalary(grossSalary);

            // Assert
            Assert.Equal(expectedTax, tax);
            taxRepositoryMock.Verify(tr => tr.SaveQuery(grossSalary, expectedTax), Times.Once);
        }
    }
}