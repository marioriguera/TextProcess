using TextProcess.Wpf.Core.Contracts.Connections;
using TextProcess.Wpf.Core.Contracts.Models;
using TextProcess.Wpf.Core.Contracts.Services;
using TextProcess.Wpf.Core.Contracts.Utils;
using TextProcess.Wpf.Core.Models.Request;
using TextProcess.Wpf.Core.Models.Response;

namespace TextProcess.Wpf.Core.Business
{
    /// <summary>
    /// Implementation of the <see cref="IOrderService"/> interface for handling text ordering operations.
    /// </summary>
    internal class OrderService : IOrderService
    {
        private readonly IHttpManager _httpManager;
        private readonly ITextManager _textManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="httpManager">The HTTP manager for making API requests.</param>
        /// <param name="textManager">The text manager for processing text.</param>
        public OrderService(IHttpManager httpManager, ITextManager textManager)
        {
            _httpManager = httpManager;
            _textManager = textManager;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<IOrderOption>> GetOrderOptionsAsync()
        {
            MessageResponse<List<OrderOptionResponse>>? response = await _httpManager.SendGetRequestAsync<MessageResponse<List<OrderOptionResponse>>>($"orders-options");
            if (response != null)
            {
                if (response.IsSuccess) return (List<OrderOptionResponse>)(response.Message ?? Enumerable.Empty<OrderOptionResponse>());

                throw new Exception($"In function {nameof(GetOrderOptionsAsync)}, the {nameof(response)} was not success.");
            }

            throw new ArgumentNullException($"In function {nameof(GetOrderOptionsAsync)}, the {nameof(response)} is null.");
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<string>> OrderAsync(IOrderText text)
        {
            OrderTextRequest cleanText = new() { TextToOrder = _textManager.RemoveLineBreaks(text.TextToOrder), OrderOption = text.OrderOption };
            MessageResponse<List<string>>? response = await _httpManager.SendPostRequestAsync<MessageResponse<List<string>>>($"order-text", cleanText);
            if (response != null)
            {
                if (response.IsSuccess) return (List<string>)(response.Message ?? Enumerable.Empty<string>());

                throw new Exception($"In function {nameof(OrderAsync)}, the {nameof(response)} was not success.");
            }

            throw new ArgumentNullException($"In function {nameof(OrderAsync)}, the {nameof(response)} is null.");
        }
    }
}
