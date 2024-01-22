using TextProcess.Wpf.Core.Contracts.Connections;
using TextProcess.Wpf.Core.Contracts.Models;
using TextProcess.Wpf.Core.Contracts.Services;
using TextProcess.Wpf.Core.Contracts.Utils;
using TextProcess.Wpf.Core.Models.Request;
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
        public async Task<ITextStatistics> TextAnalyzeAsync(string text)
        {
            string cleanText = _textManager.RemoveLineBreaks(text);
            MessageResponse<TextStatisticsResponse>? response = await _httpManager.SendPostRequestAsync<MessageResponse<TextStatisticsResponse>>($"text-statistics", new TextRequest(cleanText));
            if (response != null)
            {
                if (response.IsSuccess) return new TextStatisticsResponse(response.Message!.WordCount, response.Message!.SpaceCount, response.Message!.HyphenCount);

                throw new Exception($"In function {nameof(TextAnalyzeAsync)}, the {nameof(response)} was not success.");
            }

            throw new ArgumentNullException($"In function {nameof(TextAnalyzeAsync)}, the {nameof(response)} is null.");
        }
    }
}
