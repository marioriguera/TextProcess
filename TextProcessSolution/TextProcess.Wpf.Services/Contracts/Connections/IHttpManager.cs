namespace TextProcess.Wpf.Core.Contracts.Connections
{
    /// <summary>
    /// Represents an interface for managing HTTP requests to a specified API endpoint.
    /// </summary>
    internal interface IHttpManager
    {
        /// <summary>
        /// Changes the base URL for API requests.
        /// </summary>
        /// <param name="baseUrl">The new base URL for API requests.</param>
        void ChangeBaseUrl(string baseUrl);

        /// <summary>
        /// Sends a POST request to the specified API endpoint asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the expected response.</typeparam>
        /// <param name="subdomain">The subdomain of the API endpoint.</param>
        /// <param name="jsonData">The JSON data to be sent in the request body.</param>
        /// <returns>The deserialized response of type <typeparamref name="T"/>.</returns>
        Task<T?> SendPostRequestAsync<T>(string subdomain, object data);

        /// <summary>
        /// Sends a GET request to the specified API endpoint asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the expected response.</typeparam>
        /// <param name="subdomain">The subdomain of the API endpoint.</param>
        /// <returns>The deserialized response of type <typeparamref name="T"/>.</returns>
        Task<T?> SendGetRequestAsync<T>(string subdomain);
    }
}
