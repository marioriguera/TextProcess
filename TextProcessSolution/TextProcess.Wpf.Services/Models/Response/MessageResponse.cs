using TextProcess.Wpf.Core.Contracts.Models;

namespace TextProcess.Wpf.Core.Models.Response
{
    /// <summary>
    /// Represents a class implementing the <see cref="IMessage{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of the message content.</typeparam>
    internal class MessageResponse<T> : IMessage<T>
    {
        /// <inheritdoc/>
        public bool IsSuccess { get; set; }

        /// <inheritdoc/>
        public T? Message { get; set; }
    }
}
