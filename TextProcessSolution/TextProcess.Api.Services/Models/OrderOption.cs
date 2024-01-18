using TextProcess.Api.Core.Contracts.Models;

namespace TextProcess.Api.Core.Models
{
    /// <summary>
    /// Represents an implementation of the IOrderOption interface.
    /// </summary>
    internal class OrderOption : IOrderOption
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderOption"/> class.
        /// </summary>
        /// <param name="id">A identifier.</param>
        /// <param name="name">A order option name.</param>
        /// <param name="description">A order option descriotion.</param>
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
