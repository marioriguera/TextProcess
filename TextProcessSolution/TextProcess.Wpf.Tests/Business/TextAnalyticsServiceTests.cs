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
    /// Represents a set of unit tests for the <see cref="TextStatisticsService"/> class.
    /// </summary>
    public class TextAnalyticsServiceTests
    {
        // Fields to tests.
        private readonly MessageResponse<TextStatisticsResponse> _statisticsResposeSuccess = new() { IsSuccess = true, Message = new(6, 5, 4) };
        private readonly MessageResponse<TextStatisticsResponse> _statisticsResposeFailure = new() { IsSuccess = false, Message = null };

        // Dependencies fields.
        private readonly Mock<IHttpManager> _httpManagerMock = new();
        private readonly ITextManager _textManager = new TextManager();

        /// <summary>
        /// Tests the TextAnalyzeAsync method when the operation is successful.
        /// </summary>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous unit test.</placeholder></returns>
        [Fact]
        public async Task TextAnalyzeAsync_Success_Test()
        {
            // Arrange
            _httpManagerMock.Setup(m => m.SendPostRequestAsync<MessageResponse<TextStatisticsResponse>>($"text-statistics", It.IsAny<TextRequest>()))
                .ReturnsAsync(_statisticsResposeSuccess);

            var textStatisticsService = new TextStatisticsService(_httpManagerMock.Object, _textManager);

            // Act
            var result = await textStatisticsService.TextAnalyzeAsync("--Donec id interdum velit. Etiam rutrum.--");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(6UL, result.WordCount);
            Assert.Equal(5UL, result.SpaceCount);
            Assert.Equal(4UL, result.HyphenCount);
        }

        /// <summary>
        /// Tests the TextAnalyzeAsync method when the operation fails.
        /// </summary>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous unit test.</placeholder></returns>
        [Fact]
        public async Task TextAnalyzeAsync_Failure_Test()
        {
            // Arrange
            _httpManagerMock.Setup(m => m.SendPostRequestAsync<MessageResponse<TextStatisticsResponse>>($"text-statistics", It.IsAny<TextRequest>()))
                .ReturnsAsync(_statisticsResposeFailure);

            var textStatisticsService = new TextStatisticsService(_httpManagerMock.Object, _textManager);

            // Act & Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            await Assert.ThrowsAsync<Exception>(async () => await textStatisticsService.TextAnalyzeAsync(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }
}
