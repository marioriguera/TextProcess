using TextProcess.Api.Core.Contracts.Models;
using TextProcess.Api.Core.Contracts.Services;
using TextProcess.Api.Core.Models;

namespace TextProcess.Api.Core.Business.Analyzer
{
    /// <summary>
    /// Represents an implementation of the ITextAnalyzerService interface for analyzing text and generating text statistics.
    /// </summary>
    internal class TextAnalyzerService : ITextAnalyzerService
    {
        /// <inheritdoc/>
        public ITextStatistics TextAnalyze(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new TextStatistics(); // Returns an empty object if the string is null or empty
            }

            TextStatistics statistics = new();

            // Count words
            string[] words = SplitText(text).ToArray();
            statistics.WordCount = (ulong)words.Length;

            // Count white spaces
            statistics.SpaceCount = (ulong)text.Count(char.IsWhiteSpace);

            // Count hyphens '-'
            statistics.HyphenCount = (ulong)text.Count(c => c == '-');

            return statistics;
        }

        /// <inheritdoc/>
        public IEnumerable<string> SplitText(string text)
        {
            if (string.IsNullOrEmpty(text)) return Enumerable.Empty<string>();
            return text.Split(new[] { ' ', '\t', '\n', '\r', '-', '_', ',', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
