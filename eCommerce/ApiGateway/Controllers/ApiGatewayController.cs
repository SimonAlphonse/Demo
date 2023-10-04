using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiGatewayController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public ApiGatewayController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Orders()
        {
            var client = _clientFactory.CreateClient("OrderService");

            var response = client.GetAsync($"Order/").Result; // !! Trailing slash is mandatory
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            return NotFound();
        }
    }
}

