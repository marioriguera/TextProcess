using TextProcess.Api.Core.Contracts.Services;

namespace TextProcess.Api.Core.Business.Order
{
    /// <summary>
    /// Represents an implementation of the IOrderService interface for ordering strings alphabetically in ascending order.
    /// </summary>
    internal class AlphabeticAscOrder : IOrderService
    {
        /// <inheritdoc/>
        public IEnumerable<string> Order(IEnumerable<string> textArray)
        {
            if (!textArray.ToList().Any())
            {
                return Enumerable.Empty<string>();
            }

            // Transform to array.
            string[] words = textArray.ToArray();

            // Order the words alphabetically in ascending order
            var orderedWords = words.OrderBy(word => word, StringComparer.CurrentCultureIgnoreCase);

            return orderedWords;
        }
    }
}
