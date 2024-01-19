using TextProcess.Wpf.Core.Contracts.Models;

namespace TextProcess.Wpf.Core.Models.Response
{
    /// <summary>
    /// Represents an order option with its unique identifier, name, and description.
    /// </summary>
    internal class OrderOptionResponse : IOrderOption
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;
    }
}