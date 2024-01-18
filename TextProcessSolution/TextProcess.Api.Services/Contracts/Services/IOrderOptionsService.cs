using TextProcess.Api.Core.Contracts.Models;

namespace TextProcess.Api.Core.Contracts.Services
{
    /// <summary>
    /// Defines the contract for an order options service.
    /// </summary>
    public interface IOrderOptionsService
    {
        /// <summary>
        /// Retrieves a enumerable collection of order options.
        /// </summary>
        /// <returns>A enumerable collection  of the order options.</returns>
        IEnumerable<IOrderOption> GetOrderOptions();
    }
}
