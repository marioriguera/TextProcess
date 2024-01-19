namespace TextProcess.Wpf.Core.Contracts.Models
{
    /// <summary>
    /// Represents an interface for an order text entity with specified options.
    /// </summary>
    public interface IOrderText
    {
        /// <summary>
        /// Gets or sets the text to be ordered.
        /// </summary>
        string TextToOrder { get; set; }

        /// <summary>
        /// Gets or sets the option associated with the ordering process.
        /// </summary>
        int OrderOption { get; set; }
    }
}
