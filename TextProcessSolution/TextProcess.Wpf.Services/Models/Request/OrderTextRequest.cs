using TextProcess.Wpf.Core.Contracts.Models;

namespace TextProcess.Wpf.Core.Models.Request
{
    /// <summary>
    /// Represents a class for an order text entity with specified options for a htto request.
    /// </summary>
    internal class OrderTextRequest : IOrderText
    {
        /// <inheritdoc/>
        public string TextToOrder { get; set; } = string.Empty;

        /// <inheritdoc/>
        public int OrderOption { get; set; } = int.MinValue;
    }
}
