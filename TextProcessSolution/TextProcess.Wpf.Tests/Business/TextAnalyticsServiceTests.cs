using Moq;
using TextProcess.Wpf.Core.Contracts.Connections;
using TextProcess.Wpf.Core.Contracts.Utils;
using TextProcess.Wpf.Tests.Business.Dependencies.Models.Response;

namespace TextProcess.Wpf.Tests.Business
{
    public class TextAnalyticsServiceTests
    {
        [Fact]
        public async Task TextAnalyzeAsync_Success()
        {
            // Arrange
            // var httpManagerMock = new Mock<IHttpManager>();
            // httpManagerMock.Setup(m => m.SendPostRequestAsync<MessageResponseToTests<TextStatisticsResponse>>($"text-statistics", It.IsAny<TextRequest>()))
            //     .ReturnsAsync(new MessageResponse<TextStatisticsResponse> { IsSuccess = true, Message = new TextStatisticsResponse { WordCount = 5, SpaceCount = 10, HyphenCount = 2 } });
            // 
            // var textManagerMock = new Mock<ITextManager>();
            // textManagerMock.Setup(m => m.RemoveLineBreaks(It.IsAny<string>())).Returns<string>(input => input); // Mock RemoveLineBreaks to return the same string
            // 
            // var textStatisticsService = new TextStatisticsService(httpManagerMock.Object, textManagerMock.Object);
            // 
            // // Act
            // var result = await textStatisticsService.TextAnalyzeAsync("some text");
            // 
            // // Assert
            // Assert.NotNull(result);
            // Assert.Equal(5, result.WordCount);
            // Assert.Equal(10, result.SpaceCount);
            // Assert.Equal(2, result.HyphenCount);
            // Add more assertions based on your specific implementation
        }

        [Fact]
        public async Task TextAnalyzeAsync_Failure()
        {
            // Arrange
            /// var httpManagerMock = new Mock<IHttpManager>();
            /// httpManagerMock.Setup(m => m.SendPostRequestAsync<MessageResponse<TextStatisticsResponse>>($"text-statistics", It.IsAny<TextRequest>()))
            ///     .ReturnsAsync(new MessageResponse<TextStatisticsResponse> { IsSuccess = false });
            /// 
            /// var textManagerMock = new Mock<ITextManager>();
            /// textManagerMock.Setup(m => m.RemoveLineBreaks(It.IsAny<string>())).Returns<string>(input => input); // Mock RemoveLineBreaks to return the same string
            /// 
            /// var textStatisticsService = new TextStatisticsService(httpManagerMock.Object, textManagerMock.Object);
            /// 
            /// // Act & Assert
            /// await Assert.ThrowsAsync<Exception>(async () => await textStatisticsService.TextAnalyzeAsync("some text"));
        }
    }
}
