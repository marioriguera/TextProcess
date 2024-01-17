namespace TextProcess.Api.Contracts.Request
{
    /// <summary>
    /// Represents a request for ordering text with specified options.
    /// </summary>
    public interface IOrderTextRequest
    {
        /// <summary>
        /// Gets or sets the text to be ordered.
        /// </summary>
        string TextToOrder { get; set; }

        /// <summary>
        /// Gets or sets the option associated with the ordering process.
        /// The value must correspond to a primary identifier within the sorting options list.
        /// </summary>
        int OrderOption { get; set; }
    }
}
