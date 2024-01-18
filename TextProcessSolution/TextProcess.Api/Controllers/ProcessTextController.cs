using Microsoft.AspNetCore.Mvc;
using TextProcess.Api.Configuration;
using TextProcess.Api.Core.Contracts.Factories;
using TextProcess.Api.Core.Contracts.Models;
using TextProcess.Api.Core.Contracts.Services;
using TextProcess.Api.Models.Request;
using TextProcess.Api.Models.Response;

namespace TextProcess.Api.Controllers
{

    /// <summary>
    /// Controller for processing text-related operations such as ordering and text statistics.
    /// </summary>
    [ApiController]
    [Route("api/process-text")]
    public class ProcessTextController : Controller
    {
        private IOrderOptionsService _orderOptionsService;
        private IOrderFactory _orderFactory;
        private ITextAnalyzerService _textAnalyzerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessTextController"/> class.
        /// </summary>
        /// <param name="orderOptionsService">The service providing available order options.</param>
        /// <param name="orderFactory">The factory for creating orders.</param>
        /// <param name="textAnalyzerService">The service for analyzing text.</param>
        public ProcessTextController(IOrderOptionsService orderOptionsService, IOrderFactory orderFactory, ITextAnalyzerService textAnalyzerService)
        {
            _orderOptionsService = orderOptionsService;
            _orderFactory = orderFactory;
            _textAnalyzerService = textAnalyzerService;
        }

        /// <summary>
        /// Retrieves the available order options asynchronously.
        /// </summary>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
        [HttpGet]
        [Route("orders-options")]
        public async Task<ActionResult<MessageResponse<IEnumerable<IOrderOption>>>> GetOrdersOptionsAsync()
        {
            try
            {
                IEnumerable<IOrderOption> serviceResult = await Task.Run(() => _orderOptionsService.GetOrderOptions() ?? Enumerable.Empty<IOrderOption>());
                return Ok(MessageResponse<IEnumerable<IOrderOption>>.Success(serviceResult));
            }
            catch (Exception ex)
            {
                ConfigurationService.Current.Logger.Fatal(ex, $"Unhandled error in {nameof(GetOrdersOptionsAsync)}.");
                return BadRequest(MessageResponse<IEnumerable<IOrderOption>>.Fail(Enumerable.Empty<IOrderOption>()));
            }
        }

        /// <summary>
        /// Orders text based on the specified options asynchronously.
        /// </summary>
        /// <param name="orderTextRequest">The request containing text and ordering options.</param>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
        /// <remarks>
        /// Example requests:
        ///
        ///     GOOD:
        ///
        ///     1- AlphabeticAsc:
        ///     {
        ///        "TextToOrder": "Duis sem ligula, consequat sit amet interdum consectetur",
        ///        "OrderOption": 1
        ///     }
        ///
        ///     2- AlphabeticDesc:
        ///     {
        ///        "TextToOrder": "Duis sem ligula, consequat sit amet interdum consectetur",
        ///        "OrderOption": 2
        ///     }
        ///
        ///     3- LengthAsc:
        ///     {
        ///        "TextToOrder": "Duis sem ligula, consequat sit amet interdum consectetur",
        ///        "OrderOption": 3
        ///     }
        ///
        ///     BAD:
        ///
        ///     1- Sorting (0) option that does not exist:
        ///     {
        ///        "TextToOrder": "Duis sem ligula, consequat sit amet interdum consectetur",
        ///        "OrderOption": 0
        ///     }
        ///
        ///     2- Text with page breaks:
        ///     {
        ///        "TextToOrder": "Duis sem ligula, consequat sit amet interdum consectetur.
        ///
        ///        Duis sem ligula, consequat sit amet interdum consectetur",
        ///        "OrderOption": 2
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("order-text")]
        public async Task<ActionResult<MessageResponse<IEnumerable<string>>>> OrderTextAsync([FromBody] OrderTextRequest orderTextRequest)
        {
            try
            {
                if (!orderTextRequest.IsValid()) return BadRequest(MessageResponse<IEnumerable<string>>.Fail(Enumerable.Empty<string>()));

                IEnumerable<string> serviceResult = await Task.Run(() => _orderFactory.GetOrderText(orderTextRequest.OrderOption!.Value, orderTextRequest.TextToOrder!) ?? Enumerable.Empty<string>());

                return Ok(MessageResponse<IEnumerable<string>>.Success(serviceResult));
            }
            catch (Exception ex)
            {
                ConfigurationService.Current.Logger.Fatal(ex, $"Unhandled error in {nameof(OrderTextAsync)}.");
                return BadRequest(MessageResponse<IEnumerable<IOrderOption>>.Fail(Enumerable.Empty<IOrderOption>()));
            }
        }

        /// <summary>
        /// Retrieves text statistics based on the specified request asynchronously.
        /// </summary>
        /// <param name="statisticsOrderRequest">The request containing text for statistics.</param>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
        /// <remarks>
        /// Example requests:
        ///
        ///     GOOD:
        ///
        ///     1- Small text:
        ///     {
        ///        "Text": "Duis sem ligula, consequat sit amet interdum consectetur"
        ///     }
        ///
        ///     2- Huge text:
        ///     {
        ///        "Text": "Duis sem ligula, consequat sit amet interdum consectetur, -- feugiat vel orci. Duis imperdiet diam eu sagittis euismod. Nam convallis lacinia - faucibus. Phasellus consectetur orci a tellus elementum convallis vel nec elit. Sed ultricies arcu ac neque feugiat vulputate. Phasellus venenatis egestas nunc in aliquet. Vestibulum tincidunt sem laoreet lorem pellentesque cursus. Quisque porta lacus vitae leo varius feugiat. Donec convallis purus nisl. Quisque pretium nibh quis lacus dictum faucibus. Sed lobortis tortor eget consequat convallis. Vestibulum ultrices turpis dictum ipsum vehicula, eu tristique lectus malesuada. Pellentesque lacus eros, commodo et finibus eu, egestas ut ex. Morbi at orci enim. Donec feugiat mauris erat, sed sodales sem pretium eget."
        ///     }
        ///
        ///     BAD:
        ///
        ///     1- Null text:
        ///     {
        ///        "Text": null
        ///     }
        ///
        ///     2- Number and not a text:
        ///     {
        ///        "Text": 1
        ///     }
        ///
        ///     3- Empty text:
        ///     {
        ///        "Text":
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("text-statistics")]
        public async Task<ActionResult<MessageResponse<ITextStatistics>>> TextStatisticsAsync([FromBody] StatisticsOrderRequest statisticsOrderRequest)
        {
            try
            {
                if (!statisticsOrderRequest.IsValid()) return BadRequest(MessageResponse<object>.Fail(new object()));

                ITextStatistics serviceResult = await Task.Run(() => _textAnalyzerService.AnalyzeText(statisticsOrderRequest.Text));

                return Ok(MessageResponse<ITextStatistics>.Success(serviceResult));
            }
            catch (Exception ex)
            {
                ConfigurationService.Current.Logger.Fatal(ex, $"Unhandled error in {nameof(TextStatisticsAsync)}.");
                return BadRequest(MessageResponse<IEnumerable<IOrderOption>>.Fail(Enumerable.Empty<IOrderOption>()));
            }
        }
    }
}
