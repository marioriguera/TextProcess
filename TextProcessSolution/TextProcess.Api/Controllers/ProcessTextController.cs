using Microsoft.AspNetCore.Mvc;
using TextProcess.Api.Models.Request;
using TextProcess.Api.Models.Response;

namespace TextProcess.Api.Controllers
{
    [ApiController]
    [Route("api/process-text")]
    public class ProcessTextController : Controller
    {
        [HttpGet]
        [Route("orders-options")]
        public async Task<ActionResult<MessageResponse<string>>> GetOrdersOptionsAsync()
        {
            try
            {
                return Ok(MessageResponse<string>.Success($"Success"));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [Route("order-text")]
        public async Task<ActionResult<MessageResponse<string>>> OrderTextAsync([FromBody] OrderTextRequest orderTextRequest)
        {
            try
            {
                return Ok(MessageResponse<string>.Success($"Success"));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [Route("text-statistics")]
        public async Task<ActionResult<MessageResponse<string>>> TextStatisticsAsync([FromBody] OrderTextRequest orderTextRequest)
        {
            try
            {
                return Ok(MessageResponse<string>.Success($"Success"));
            }
            catch
            {
                return View();
            }
        }
    }
}
