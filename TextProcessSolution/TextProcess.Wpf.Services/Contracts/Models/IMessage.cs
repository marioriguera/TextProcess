namespace TextProcess.Wpf.Core.Contracts.Models
{
    /// <summary>
    /// Represents an interface for a message with generic content.
    /// </summary>
    /// <typeparam name="T">The type of the message content.</typeparam>
    public interface IMessage<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the response is successful.
        /// </summary>
        bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the content of the message response.
        /// </summary>
        T? Message { get; set; }
    }
}
