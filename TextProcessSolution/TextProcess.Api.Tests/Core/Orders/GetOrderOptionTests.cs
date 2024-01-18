using Microsoft.Extensions.DependencyInjection;
using TextProcess.Api.Core.Contracts.Services;
using TextProcess.Api.Tests.Core.Configurations;

namespace TextProcess.Api.Tests.Core.Orders
{
    /// <summary>
    /// Unit test for the GetOrderOptions method in the OrderOptionsService class.
    /// </summary>
    public class GetOrderOptionTests
    {
        private readonly IOrderOptionsService _orderOptionsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderOptionTests"/> class.
        /// </summary>
        public GetOrderOptionTests()
        {
            // Obtain the IOrderOptionsService from the service collection
            _orderOptionsService = ConfigurationServiceTests.Current.TestHost.Services.GetRequiredService<IOrderOptionsService>();
        }

        /// <summary>
        /// Ensures that GetOrderOptions returns the correct number of elements (three).
        /// </summary>
        [Fact]
        public void GetOrderOptions_ReturnsCorrectNumberOfElements()
        {
            // Act
            var result = _orderOptionsService.GetOrderOptions();

            // Assert
            Assert.Equal(3, result.ToList().Count);
        }

        /// <summary>
        /// Verifies that calling GetOrderOptions returns the correct first option.
        /// </summary>
        [Fact]
        public void GetOrderOptions_ReturnsCorrectOptionOne()
        {
            // Act
            var result = _orderOptionsService.GetOrderOptions();

            // Assert
            Assert.Equal($"AlphabeticAsc", result.First().Name);
        }

        /// <summary>
        /// Verifies that calling GetOrderOptions returns the correct second option.
        /// </summary>
        [Fact]
        public void GetOrderOptions_ReturnsCorrectOptionTwo()
        {
            // Act
            var result = _orderOptionsService.GetOrderOptions();

            // Assert
            Assert.Equal($"AlphabeticDesc", result.Skip(1).First().Name);
        }

        /// <summary>
        /// Verifies that calling GetOrderOptions returns the correct third option.
        /// </summary>
        [Fact]
        public void GetOrderOptions_ReturnsCorrectOptionThree()
        {
            // Act
            var result = _orderOptionsService.GetOrderOptions();

            // Assert
            Assert.Equal($"LengthAsc", result.Skip(2).First().Name);
        }
    }
}
