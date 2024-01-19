using TextProcess.Wpf.Core.Contracts.Models;

namespace TextProcess.Wpf.Models
{
    /// <summary>
    /// Represents a concrete implementation of the <see cref="IOrderOption"/> interface.
    /// </summary>
    internal class OrderOption : IOrderOption
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderOption"/> class with specified parameters.
        /// </summary>
        /// <param name="id">The unique identifier for the order option.</param>
        /// <param name="name">The name of the order option.</param>
        /// <param name="description">The description of the order option.</param>
        public OrderOption(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public string Description { get; set; }
    }
}
