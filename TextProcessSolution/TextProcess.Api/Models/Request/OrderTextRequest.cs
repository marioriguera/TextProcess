using System.Text;
using TextProcess.Api.Configuration;
using TextProcess.Api.Contracts;

namespace TextProcess.Api.Models.Request
{
    /// <summary>
    /// Represents a class for a request to order text with specified options.
    /// </summary>
    public class OrderTextRequest : IValidRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTextRequest"/> class with the specified parameters.
        /// </summary>
        /// <param name="textToOrder">The text to be ordered. Must not be <c>null</c>.</param>
        /// <param name="orderOption">The option associated with the ordering process.</param>
        public OrderTextRequest(string? textToOrder, int? orderOption)
        {
            TextToOrder = textToOrder;
            OrderOption = orderOption;
        }

        /// <summary>
        /// Gets or sets the text to be ordered.
        /// </summary>
        public string? TextToOrder { get; set; }

        /// <summary>
        /// Gets or sets the option associated with the ordering process.
        /// The value must correspond to a primary identifier within the sorting options list.
        /// </summary>
        public int? OrderOption { get; private set; }

        /// <inheritdoc/>
        public bool IsValid()
        {
            bool isValid = !string.IsNullOrEmpty(TextToOrder) && OrderOption != null;
            if (!isValid) ConfigurationService.Current.Logger.Warn($"A {nameof(OrderTextRequest)} class is invalid. {ToString()}");
            return isValid;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"{nameof(TextToOrder)} = {TextToOrder ?? string.Empty} , {nameof(OrderOption)} = {(OrderOption == null ? string.Empty : OrderOption.ToString())}");

            return builder.ToString();
        }
    }
}
