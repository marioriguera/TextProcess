namespace TextProcess.Api.Models.Response
{
    /// <summary>
    /// Represents an immutable record for a generic message response with success status and content.
    /// </summary>
    /// <typeparam name="T">The type of the message content.</typeparam>
    public record MessageResponse<T>
    {
        // Private constructor to enforce immutability.
        private MessageResponse() { }

        /// <summary>
        /// Gets or sets a value indicating whether the response is successful.
        /// </summary>
        public bool? IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the content of the message response.
        /// </summary>
        public T? Message { get; set; }

        /// <summary>
        /// Creates an instance of <see cref="MessageResponse{T}"/> with a failed status and specified content.
        /// </summary>
        /// <param name="content">The content of the failed message response.</param>
        /// <returns>An immutable instance of <see cref="MessageResponse{T}"/> with a failed status and content.</returns>
        public static MessageResponse<T> Fail(T content)
        {
            MessageResponse<T> messageResponse = new MessageResponse<T>();
            messageResponse.IsSuccess = false;
            messageResponse.Message = content;
            return messageResponse;
        }

        /// <summary>
        /// Creates an instance of <see cref="MessageResponse{T}"/> with a successful status and specified content.
        /// </summary>
        /// <param name="content">The content of the successful message response.</param>
        /// <returns>An immutable instance of <see cref="MessageResponse{T}"/> with a successful status and content.</returns>
        public static MessageResponse<T> Success(T content)
        {
            MessageResponse<T> messageResponse = new MessageResponse<T>();
            messageResponse.IsSuccess = true;
            messageResponse.Message = content;
            return messageResponse;
        }
    }
}
