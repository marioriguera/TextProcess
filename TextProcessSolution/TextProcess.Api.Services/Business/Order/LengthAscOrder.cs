using TextProcess.Api.Core.Contracts.Services;

namespace TextProcess.Api.Core.Business.Order
{
    /// <summary>
    /// Represents an implementation of the IOrderService interface for ordering strings by length in ascending order.
    /// </summary>
    internal class LengthAscOrder : IOrderService
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

            // Order the words by length from shortest to longest
            var orderedWords = words.OrderBy(word => word.Length);

            return orderedWords;
        }
    }
}
