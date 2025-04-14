
using Microsoft.AspNetCore.Mvc;
using Moq;
using Taxually.TechnicalTest.Controllers;
using Taxually.TechnicalTest.Services;
using Taxually.TechnicalTest.Models;



namespace IvatRegistrationTest
{
    public class VatRegistrationControllerTests
    {
        private readonly Mock<IVatRegistrationStrategyFactory> _mockFactory;
        private readonly VatRegistrationController _controller;

        public VatRegistrationControllerTests()
        {
            _mockFactory = new Mock<IVatRegistrationStrategyFactory>();
            _controller = new VatRegistrationController(_mockFactory.Object);
        }

        [Fact]
        public async Task Post_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new VatRegistrationRequest
            {
                CompanyName = "Test Ltd",
                CompanyId = "123",
                Country = "GB"
            };
            var mockStrategy = new Mock<IVatRegistrationStrategy>();
            _mockFactory.Setup(f => f.GetStrategy("GB")).Returns(mockStrategy.Object);

            // Act
            var result = await _controller.Post(request);

            // Assert
            Assert.IsType<OkResult>(result);
            mockStrategy.Verify(s => s.RegisterAsync(request), Times.Once());
        }

        [Fact]
        public async Task Post_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var request = new VatRegistrationRequest();
            _controller.ModelState.AddModelError("Country", "The Country field is required.");

            // Act
            var result = await _controller.Post(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
    
}