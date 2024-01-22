using System.Text;
using Newtonsoft.Json;
using TextProcess.Wpf.Core.Contracts.Connections;

namespace TextProcess.Wpf.Core.Connections
{
    /// <summary>
    /// Implementation of the HTTP manager responsible for sending POST and GET requests.
    /// </summary>
    internal class HttpManager : IHttpManager
    {
        private static readonly HttpClient _httpClient = new();
        private static string _baseUrl = "https://localhost:7062/api/process-text";

        /// <inheritdoc/>
        public void ChangeBaseUrl(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        /// <inheritdoc/>
        public async Task<T?> SendPostRequestAsync<T>(string subdomain, object data)
            where T : class
        {
            try
            {
                // Serialize
                string jsonData = JsonConvert.SerializeObject(data);

                // Create the request content
                StringContent content = new(jsonData, Encoding.UTF8, "application/json");

                // Build the complete URL with subdomain
                string apiUrl = $"{_baseUrl}/{subdomain}";

                // Send the POST request
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // Process the successful response
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    T? result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonResponse);

                    return result;
                }
                else
                {
                    // Handle API errors
                    throw new HttpRequestException($"Error in the request: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                // Handle network or other exceptions
                throw new Exception($"Error: {ex.Message}");
            }
        }

        /// <inheritdoc/>
        public async Task<T?> SendGetRequestAsync<T>(string subdomain)
            where T : class
        {
            try
            {
                // Build the complete URL with subdomain
                string apiUrl = $"{_baseUrl}/{subdomain}";

                // Send the GET request
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read and deserialize the JSON response
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    T? result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonResponse);

                    return result;
                }
                else
                {
                    // Handle API errors
                    throw new HttpRequestException($"Error in the request: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                // Handle network or other exceptions
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
