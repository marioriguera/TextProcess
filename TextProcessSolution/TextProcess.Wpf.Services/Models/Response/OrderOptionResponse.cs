using TextProcess.Wpf.Core.Contracts.Models;

namespace TextProcess.Wpf.Core.Models.Response
{
    /// <summary>
    /// Represents an order option with its unique identifier, name, and description.
    /// </summary>
    internal class OrderOptionResponse : IOrderOption
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderOptionResponse"/> class with the specified values.
        /// </summary>
        /// <param name="id">The unique identifier of the order option.</param>
        /// <param name="name">The name of the order option.</param>
        /// <param name="description">The description of the order option.</param>
        public OrderOptionResponse(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;
    }
}