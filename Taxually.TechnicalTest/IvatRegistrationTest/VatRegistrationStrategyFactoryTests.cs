using Moq;
using Taxually.TechnicalTest.Services;
using Taxually.TechnicalTest.Services.Strategies;
using Xunit;

namespace Taxually.TechnicalTest.Tests
{
    public class VatRegistrationStrategyFactoryTests
    {
        private readonly VatRegistrationStrategyFactory _factory;

        public VatRegistrationStrategyFactoryTests()
        {
            var mockHttpClient = new Mock<TaxuallyHttpClient>();
            var mockQueueClient = new Mock<TaxuallyQueueClient>();
            _factory = new VatRegistrationStrategyFactory(mockHttpClient.Object, mockQueueClient.Object);
        }

        [Fact]
        public void GetStrategy_GB_ReturnsApiStrategy()
        {
            // Act
            var strategy = _factory.GetStrategy("GB");

            // Assert
            Assert.IsType<ApiVatRegistrationStrategy>(strategy);
        }

        [Fact]
        public void GetStrategy_FR_ReturnsCsvStrategy()
        {
            // Act
            var strategy = _factory.GetStrategy("FR");

            // Assert
            Assert.IsType<CsvVatRegistrationStrategy>(strategy);
        }
    }
}