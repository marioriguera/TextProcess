using TextProcess.Wpf.Core.Contracts.Models;

namespace TextProcess.Wpf.Models
{
    /// <summary>
    /// Represents a class implementing the <see cref="IOrderText"/> interface.
    /// </summary>
    internal class OrderText : IOrderText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderText"/> class with the specified parameters.
        /// </summary>
        /// <param name="textToOrder">The text to be ordered.</param>
        /// <param name="orderOption">The option associated with the ordering process.</param>
        public OrderText(string textToOrder, int orderOption)
        {
            TextToOrder = textToOrder;
            OrderOption = orderOption;
        }

        /// <inheritdoc/>
        public string TextToOrder { get; set; } = string.Empty;

        /// <inheritdoc/>
        public int OrderOption { get; set; } = int.MinValue;
    }
}
