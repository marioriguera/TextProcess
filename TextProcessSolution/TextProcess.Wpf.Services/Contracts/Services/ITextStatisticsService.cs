using TextProcess.Wpf.Core.Contracts.Models;

namespace TextProcess.Wpf.Core.Contracts.Services
{
    /// <summary>
    /// Interface for a service that provides text analysis statistics.
    /// </summary>
    public interface ITextStatisticsService
    {
        /// <summary>
        /// Analyzes the specified text asynchronously and returns the corresponding text statistics.
        /// </summary>
        /// <param name="text">The text to be analyzed.</param>
        /// <returns>A task representing the asynchronous operation. The result is the analyzed text statistics.</returns>
        Task<ITextStatistics> TextAnalyzeAsync(string text);
    }
}
