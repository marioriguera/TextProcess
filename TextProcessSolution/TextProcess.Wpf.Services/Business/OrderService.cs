using System.Collections.Generic;
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
        public async Task<IMessage<IEnumerable<IOrderOption>>?> GetOrderOptionsAsync()
        {
            IMessage<IEnumerable<IOrderOption>>? result = (IMessage<IEnumerable<IOrderOption>>?)await _httpManager.SendGetRequestAsync<MessageResponse<List<OrderOptionResponse>>>($"orders-options");
            return result;
        }

        /// <inheritdoc/>
        public async Task<IMessage<IEnumerable<string>>?> OrderAsync(IOrderText text)
        {
            OrderTextRequest cleanText = new OrderTextRequest() { TextToOrder = _textManager.RemoveLineBreaks(text.TextToOrder), OrderOption = text.OrderOption };
            // ToDo: me quede por aqui. Debo hacer que cada clase de request sea capaz de serializar el objeto y llevarlo a un string.
            IMessage<IEnumerable<string>>? result = (IMessage<IEnumerable<string>>?)(await _httpManager.SendPostRequestAsync<MessageResponse<List<string>>>($"order-text", "cleanText"));
            return result;
        }
    }
}
