using Microsoft.Extensions.DependencyInjection;
using TextProcess.Api.Core.Contracts.Factories;
using TextProcess.Api.Tests.Core.Configurations;

namespace TextProcess.Api.Tests.Core.Orders
{
    /// <summary>
    /// Represents unit tests for the IOrderFactory to ensure correct order generation.
    /// </summary>
    public class OrderFactoryAlphabeticAscTests
    {
        private readonly IOrderFactory _orderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFactoryAlphabeticAscTests"/> class.
        /// </summary>
        public OrderFactoryAlphabeticAscTests()
        {
            _orderFactory = ConfigurationServiceTests.Current.TestHost.Services.GetRequiredService<IOrderFactory>();
        }

        /// <summary>
        /// Tests the AlphabeticAsc order with a basic input.
        /// </summary>
        [Fact]
        public void AlphabeticAsc_Basic_Test()
        {
            var result = _orderFactory.GetOrderText(1, "Aaa Bbb Ccc").ToList();

            Assert.Equal("Aaa", result.First());
            Assert.Equal("Bbb", result.Skip(1).First());
            Assert.Equal("Ccc", result.Skip(2).First());
        }

        /// <summary>
        /// Tests the AlphabeticAsc order with names as input.
        /// </summary>
        [Fact]
        public void AlphabeticAsc_Names_Test()
        {
            var result = _orderFactory.GetOrderText(1, "Mario Antonia Pedro").ToList();

            Assert.Equal("Antonia", result.First());
            Assert.Equal("Mario", result.Skip(1).First());
            Assert.Equal("Pedro", result.Skip(2).First());
        }

        /// <summary>
        /// Tests the AlphabeticAsc order with an empty input, expecting an empty enumeration.
        /// </summary>
        [Fact]
        public void AlphabeticAsc_Empty_Test()
        {
            var result = _orderFactory.GetOrderText(1, string.Empty).ToList();

            Assert.Empty(result);
        }

        /// <summary>
        /// Tests the AlphabeticAsc order with a null input, expecting an empty enumeration.
        /// </summary>
        [Fact]
        public void AlphabeticAsc_Null_Test()
        {
            var result = _orderFactory.GetOrderText(1, null).ToList();

            Assert.Empty(result);
        }
    }
}
