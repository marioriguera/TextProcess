using Microsoft.Extensions.DependencyInjection;
using TextProcess.Api.Core.Contracts.Factories;
using TextProcess.Api.Tests.Core.Configurations;

namespace TextProcess.Api.Tests.Core.Orders
{
    /// <summary>
    /// Represents unit tests for the IOrderFactory with AlphabeticDesc order to ensure correct order generation.
    /// </summary>
    public class OrderFactoryAlphabeticDescTests
    {
        private readonly IOrderFactory _orderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFactoryAlphabeticDescTests"/> class.
        /// </summary>
        public OrderFactoryAlphabeticDescTests()
        {
            _orderFactory = ConfigurationServiceTests.Current.TestHost.Services.GetRequiredService<IOrderFactory>();
        }

        /// <summary>
        /// Tests the AlphabeticDesc order with a basic input.
        /// </summary>
        [Fact]
        public void AlphabeticDesc_Basic_Test()
        {
            var result = _orderFactory.GetOrderText(2, "Aaa Bbb Ccc").ToList();

            Assert.Equal("Ccc", result.First());
            Assert.Equal("Bbb", result.Skip(1).First());
            Assert.Equal("Aaa", result.Skip(2).First());
        }

        /// <summary>
        /// Tests the AlphabeticDesc order with names as input.
        /// </summary>
        [Fact]
        public void AlphabeticDesc_Names_Test()
        {
            var result = _orderFactory.GetOrderText(2, "Mario Antonia Pedro").ToList();

            Assert.Equal("Pedro", result.First());
            Assert.Equal("Mario", result.Skip(1).First());
            Assert.Equal("Antonia", result.Skip(2).First());
        }

        /// <summary>
        /// Tests the AlphabeticDesc order with an empty input, expecting an empty enumeration.
        /// </summary>
        [Fact]
        public void AlphabeticDesc_Empty_Test()
        {
            var result = _orderFactory.GetOrderText(2, string.Empty).ToList();

            Assert.Empty(result);
        }

        /// <summary>
        /// Tests the AlphabeticDesc order with a null input, expecting an empty enumeration.
        /// </summary>
        [Fact]
        public void AlphabeticDesc_Null_Test()
        {
#pragma warning disable CS8625 // No se puede convertir un literal NULL en un tipo de referencia que no acepta valores NULL.
            var result = _orderFactory.GetOrderText(2, null).ToList();
#pragma warning restore CS8625 // No se puede convertir un literal NULL en un tipo de referencia que no acepta valores NULL.

            Assert.Empty(result);
        }
    }
}
