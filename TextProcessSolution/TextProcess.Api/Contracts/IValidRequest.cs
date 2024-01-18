namespace TextProcess.Api.Contracts
{
    /// <summary>
    /// Represents an interface for validating a request.
    /// </summary>
    public interface IValidRequest
    {
        /// <summary>
        /// Checks whether the request is valid.
        /// </summary>
        /// <returns><c>true</c> if the request is valid; otherwise, <c>false</c>.</returns>
        bool IsValid();
    }
}
