using TextProcess.Api.Core.Business.Order;
using TextProcess.Api.Core.Contracts.Factories;
using TextProcess.Api.Core.Contracts.Services;

namespace TextProcess.Api.Core.Business.Factory
{
    /// <summary>
    /// Represents a factory for creating ordered sequences of strings based on a specific order.
    /// </summary>
    internal class OrderFactory : IOrderFactory
    {
        private readonly ITextAnalyzerService _textAnalyzer;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFactory"/> class.
        /// </summary>
        /// <param name="textAnalyzer">The ITextAnalyzer instance used for text analysis.</param>
        public OrderFactory(ITextAnalyzerService textAnalyzer)
        {
            _textAnalyzer = textAnalyzer;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetOrderText(int orderId, string text)
        {
            var instance = GetInstance(orderId);
            return instance.Order(_textAnalyzer.SplitText(text));
        }

        /// <summary>
        /// Gets an instance of an object implementing the IOrderService interface based on the specified order.
        /// </summary>
        /// <param name="orderId">The order criteria for selecting the appropriate IOrder implementation.</param>
        /// <returns>An instance of the IOrder interface corresponding to the specified order.</returns>
        private IOrderService GetInstance(int orderId)
        {
            switch (orderId)
            {
                // AlphabeticAsc
                case 1:
                    return new AlphabeticAscOrder();

                // AlphabeticDesc
                case 2:
                    return new AlphabeticDescOrder();

                // LengthAsc
                case 3:
                    return new LengthAscOrder();
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderId), "Not a valid order option.");
            }
        }
    }
}
