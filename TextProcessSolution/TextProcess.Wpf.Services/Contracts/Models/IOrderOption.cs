namespace TextProcess.Wpf.Core.Contracts.Models
{
    /// <summary>
    /// Represents an order option.
    /// </summary>
    public interface IOrderOption
    {
        /// <summary>
        /// Gets or sets the ID of the order option.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the order option.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the order option.
        /// </summary>
        string Description { get; set; }
    }
}
