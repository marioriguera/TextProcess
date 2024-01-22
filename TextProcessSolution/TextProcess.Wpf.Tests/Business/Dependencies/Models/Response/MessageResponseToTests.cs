namespace TextProcess.Wpf.Tests.Business.Dependencies.Models.Response
{
    internal class MessageResponseToTests<T> : Core.Contracts.Models.IMessage<T>
    {
        /// <inheritdoc/>
        public bool IsSuccess { get; set; }

        /// <inheritdoc/>
        public T? Message { get; set; }
    }
}
