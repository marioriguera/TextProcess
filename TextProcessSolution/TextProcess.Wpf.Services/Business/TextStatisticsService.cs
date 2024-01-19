using TextProcess.Wpf.Core.Contracts.Connections;
using TextProcess.Wpf.Core.Contracts.Models;
using TextProcess.Wpf.Core.Contracts.Services;
using TextProcess.Wpf.Core.Contracts.Utils;
using TextProcess.Wpf.Core.Models.Response;

namespace TextProcess.Wpf.Core.Business
{
    /// <summary>
    /// Implementation of <see cref="ITextStatisticsService"/> for analyzing text statistics.
    /// </summary>
    internal class TextStatisticsService : ITextStatisticsService
    {
        private readonly IHttpManager _httpManager;
        private readonly ITextManager _textManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextStatisticsService"/> class.
        /// </summary>
        /// <param name="httpManager">The HTTP manager for making API requests.</param>
        /// <param name="textManager">The text manager for processing and cleaning text.</param>
        public TextStatisticsService(IHttpManager httpManager, ITextManager textManager)
        {
            _httpManager = httpManager;
            _textManager = textManager;
        }

        /// <inheritdoc/>
        public async Task<IMessage<ITextStatistics>?> TextAnalyzeAsync(string text)
        {
            string cleanText = _textManager.RemoveLineBreaks(text);
            IMessage<ITextStatistics>? result = (IMessage<ITextStatistics>?)(await _httpManager.SendPostRequestAsync<MessageResponse<TextStatisticsResponse>>($"text-statistics", cleanText));
            return result;
        }
    }
}
