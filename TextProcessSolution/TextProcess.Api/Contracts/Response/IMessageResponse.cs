namespace TextProcess.Api.Contracts.Response
{
    /// <summary>
    /// Represents a generic message response with success status and content.
    /// </summary>
    /// <typeparam name="T">The type of the message content.</typeparam>
    public interface IMessageResponse<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the response is successful.
        /// </summary>
        bool? IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the content of the message response.
        /// </summary>
        T? Message { get; set; }

        /// <summary>
        /// Creates a message response with a failed status and specified content.
        /// </summary>
        /// <param name="content">The content of the failed message response.</param>
        /// <returns>An instance of <see cref="IMessageResponse{T}"/> with a failed status and content.</returns>
        IMessageResponse<T> Fail(T content);

        /// <summary>
        /// Creates a message response with a successful status and specified content.
        /// </summary>
        /// <param name="content">The content of the successful message response.</param>
        /// <returns>An instance of <see cref="IMessageResponse{T}"/> with a successful status and content.</returns>
        IMessageResponse<T> Success(T content);
    }
}
