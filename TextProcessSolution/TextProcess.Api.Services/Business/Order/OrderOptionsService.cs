using TextProcess.Api.Core.Contracts.Models;
using TextProcess.Api.Core.Contracts.Services;
using TextProcess.Api.Core.Models;

namespace TextProcess.Api.Core.Business.Order
{
    /// <summary>
    /// Provides the implementation of the IOrderOptionsService interface.
    /// </summary>
    internal class OrderOptionsService : IOrderOptionsService
    {
        private readonly List<IOrderOption> _orderOptions = new List<IOrderOption>()
        {
                                        { new OrderOption(1, "AlphabeticAsc", "Alfabetico ascendente") },
                                        { new OrderOption(2, "AlphabeticDesc", "Alfabetico descendente") },
                                        { new OrderOption(3, "LengthAsc", "Tamaño ascendente") },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderOptionsService"/> class.
        /// </summary>
        public OrderOptionsService()
        {
        }

        /// <inheritdoc/>
        public IEnumerable<IOrderOption> GetOrderOptions()
        {
            return _orderOptions;
        }
    }
}
