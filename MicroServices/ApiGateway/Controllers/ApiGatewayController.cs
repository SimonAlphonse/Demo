using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ApiGatewayController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;

    public ApiGatewayController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpGet("Order/{orderId}")]
    public async Task<IActionResult> GetOrder(int orderId)
    {
        var client = _clientFactory.CreateClient("OrderService");
        
        var response = client.GetAsync($"Order/{orderId}").Result;
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }
        return NotFound();
    }

    [HttpGet("Users")]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            var client = _clientFactory.CreateClient("UserService");
            var response = client.GetAsync($"/User/GetUsers").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
        }
        catch (AggregateException ex)
        {

        }
        return NotFound();
    }

    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetUser(int userId)
    {
        var client = _clientFactory.CreateClient("UserService");
        var response = client.GetAsync($"User/{userId}").Result;
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }
        return NotFound();
    }
}
