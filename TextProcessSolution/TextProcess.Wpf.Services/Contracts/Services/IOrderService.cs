using TextProcess.Wpf.Core.Contracts.Models;

namespace TextProcess.Wpf.Core.Contracts.Services
{
    /// <summary>
    /// Represents a service for handling text ordering operations.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Retrieves available order options asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a collection of order options.</returns>
        Task<IEnumerable<IOrderOption>> GetOrderOptionsAsync();

        /// <summary>
        /// Orders the specified text asynchronously based on the selected options.
        /// </summary>
        /// <param name="text">The text to be ordered.</param>
        /// <returns>A task representing the asynchronous operation that returns a collection of ordered strings.</returns>
        Task<IEnumerable<string>> OrderAsync(IOrderText text);
    }
}
