using TextProcess.Wpf.Core.Contracts.Models;

namespace TextProcess.Wpf.Core.Models.Response
{
    /// <summary>
    /// Represents text statistics including word count, space count, and hyphen count.
    /// </summary>
    internal class TextStatisticsResponse : ITextStatistics
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextStatisticsResponse"/> class with default values.
        /// </summary>
        public TextStatisticsResponse()
            : this(ulong.MinValue, ulong.MinValue, ulong.MinValue)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextStatisticsResponse"/> class with specified parameters.
        /// </summary>
        /// <param name="wordCount">The count of words in the text.</param>
        /// <param name="spaceCount">The count of spaces in the text.</param>
        /// <param name="hyphenCount">The count of hyphens in the text.</param>
        public TextStatisticsResponse(ulong wordCount, ulong spaceCount, ulong hyphenCount)
        {
            WordCount = wordCount;
            SpaceCount = spaceCount;
            HyphenCount = hyphenCount;
        }

        /// <inheritdoc/>
        public ulong WordCount { get; set; } = ulong.MinValue;

        /// <inheritdoc/>
        public ulong SpaceCount { get; set; } = ulong.MinValue;

        /// <inheritdoc/>
        public ulong HyphenCount { get; set; } = ulong.MinValue;
    }
}
