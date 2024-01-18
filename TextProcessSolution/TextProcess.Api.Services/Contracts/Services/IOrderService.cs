using TextProcess.Api.Core.Contracts.Models;

namespace TextProcess.Api.Core.Contracts.Services
{
    /// <summary>
    /// Defines the contract for an order service.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Orders the provided text IEnumerable and returns an IEnumerable of strings.
        /// </summary>
        /// <param name="words">The input words collection to be ordered.</param>
        /// <returns>An IEnumerable of strings representing the ordered words.</returns>
        IEnumerable<string> Order(IEnumerable<string> words);
    }
}
