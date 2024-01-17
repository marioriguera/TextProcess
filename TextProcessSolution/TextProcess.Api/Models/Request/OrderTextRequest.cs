using TextProcess.Api.Contracts.Request;

namespace TextProcess.Api.Models.Request
{
    /// <summary>
    /// Represents an immutable record for a request to order text with specified options.
    /// </summary>
    public record OrderTextRequest : IOrderTextRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTextRequest"/> record with the specified parameters.
        /// </summary>
        /// <param name="textToOrder">The text to be ordered. Must not be <c>null</c>.</param>
        /// <param name="orderOption">The option associated with the ordering process.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="textToOrder"/> is <c>null</c>.
        /// </exception>
        public OrderTextRequest(string textToOrder, int orderOption)
        {
            TextToOrder = textToOrder ?? throw new ArgumentNullException(nameof(textToOrder), $"Text to order can't be null.");
            OrderOption = orderOption;
        }

        /// <inheritdoc/>
        public string TextToOrder { get; set; }

        /// <inheritdoc/>
        public int OrderOption { get; set; }
    }
}
