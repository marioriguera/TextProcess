using TextProcess.Wpf.Core.Contracts.Models;

namespace TextProcess.Wpf.Core.Models.Response
{
    /// <summary>
    /// Represents text statistics including word count, space count, and hyphen count.
    /// </summary>
    internal class TextStatisticsResponse : ITextStatistics
    {
        /// <inheritdoc/>
        public ulong WordCount { get; set; } = ulong.MinValue;

        /// <inheritdoc/>
        public ulong SpaceCount { get; set; } = ulong.MinValue;

        /// <inheritdoc/>
        public ulong HyphenCount { get; set; } = ulong.MinValue;
    }
}
