using Moq;
using TextProcess.Wpf.Core.Business;
using TextProcess.Wpf.Core.Contracts.Connections;
using TextProcess.Wpf.Core.Contracts.Utils;
using TextProcess.Wpf.Core.Models.Request;
using TextProcess.Wpf.Core.Models.Response;
using TextProcess.Wpf.Core.Utils;

namespace TextProcess.Wpf.Tests.Business
{
    /// <summary>
    /// Represents a test suite for the <see cref="OrderService"/> class.
    /// </summary>
    public class OrderServiceTests
    {
        // Fields to tests.
        // Order options
        private readonly MessageResponse<List<OrderOptionResponse>> _orderOptionResposeSuccess = new()
        {
            IsSuccess = true,
            Message = new()
        {
            { new OrderOptionResponse(1, "AlphabeticAsc", "Alfabetico ascendente") },
            { new OrderOptionResponse(2, "AlphabeticDesc", "Alfabetico descendente") },
            { new OrderOptionResponse(3, "LengthAsc", "Tamaño ascendente") },
        },
        };

        private readonly MessageResponse<List<OrderOptionResponse>> _orderOptionResposeFailure = new() { IsSuccess = false, Message = null };

        // Order
        private readonly OrderTextRequest _orderTextRequest = new()
        {
            OrderOption = 1,
            TextToOrder = $"Aaa Bbb Ccc",
        };

        private readonly MessageResponse<List<string>> _orderResposeSuccess = new()
        {
            IsSuccess = true,
            Message = new()
        {
            "Aaa",
            "Bbb",
            "Ccc",
        },
        };

        private readonly MessageResponse<List<string>> _orderResposeFailure = new() { IsSuccess = false, Message = null };

        // Dependencies fields.
        private readonly Mock<IHttpManager> _httpManagerMock = new();
        private readonly ITextManager _textManager = new TextManager();

        /// <summary>
        /// Tests the asynchronous method for getting order options successfully.
        /// </summary>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous unit test.</placeholder></returns>
        [Fact]
        public async Task GetOrderOptionsAsync_Success_Test()
        {
            // Arrange
            _httpManagerMock.Setup(m => m.SendGetRequestAsync<MessageResponse<List<OrderOptionResponse>>>($"orders-options"))
                .ReturnsAsync(_orderOptionResposeSuccess);

            var orderService = new OrderService(_httpManagerMock.Object, _textManager);

            // Act
            var result = await orderService.GetOrderOptionsAsync();

            // Asserts
            // Not null
            Assert.NotNull(result);

            // First
            Assert.Equal(1, result.First().Id);
            Assert.Equal("AlphabeticAsc", result.First().Name);
            Assert.Equal("Alfabetico ascendente", result.First().Description);

            // Second
            Assert.Equal(2, result.Skip(1).First().Id);
            Assert.Equal("AlphabeticDesc", result.Skip(1).First().Name);
            Assert.Equal("Alfabetico descendente", result.Skip(1).First().Description);

            // Third
            Assert.Equal(3, result.Skip(2).First().Id);
            Assert.Equal("LengthAsc", result.Skip(2).First().Name);
            Assert.Equal("Tamaño ascendente", result.Skip(2).First().Description);
        }

        /// <summary>
        /// Tests the asynchronous method for getting order options with failure.
        /// </summary>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous unit test.</placeholder></returns>
        [Fact]
        public async Task GetOrderOptionsAsync_Failure_Test()
        {
            // Arrange
            _httpManagerMock.Setup(m => m.SendGetRequestAsync<MessageResponse<List<OrderOptionResponse>>>($"orders-options"))
                .ReturnsAsync(_orderOptionResposeFailure);

            var orderService = new OrderService(_httpManagerMock.Object, _textManager);

            // Act & Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            await Assert.ThrowsAsync<Exception>(async () => await orderService.GetOrderOptionsAsync());
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        /// <summary>
        /// Tests the asynchronous method for ordering text successfully.
        /// </summary>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous unit test.</placeholder></returns>
        [Fact]
        public async Task OrderAsync_Success_Test()
        {
            // Arrange
            _httpManagerMock.Setup(m => m.SendPostRequestAsync<MessageResponse<List<string>>>($"order-text", It.IsAny<OrderTextRequest>()))
                .ReturnsAsync(_orderResposeSuccess);

            var orderService = new OrderService(_httpManagerMock.Object, _textManager);

            // Act
            var result = await orderService.OrderAsync(_orderTextRequest);

            // Asserts
            // Not null
            Assert.NotNull(result);

            Assert.Equal("Aaa", result.First());
            Assert.Equal("Bbb", result.Skip(1).First());
            Assert.Equal("Ccc", result.Skip(2).First());
        }

        /// <summary>
        /// Tests the asynchronous method for ordering text with failure.
        /// </summary>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous unit test.</placeholder></returns>
        [Fact]
        public async Task OrderAsync_Failure_Test()
        {
            // Arrange
            _httpManagerMock.Setup(m => m.SendPostRequestAsync<MessageResponse<List<string>>>($"order-text", It.IsAny<OrderTextRequest>()))
                .ReturnsAsync(_orderResposeFailure);

            var orderService = new OrderService(_httpManagerMock.Object, _textManager);

            // Act & Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            await Assert.ThrowsAsync<Exception>(async () => await orderService.OrderAsync(_orderTextRequest));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }
}
