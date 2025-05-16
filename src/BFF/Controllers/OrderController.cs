using BFF.DTOs;
using BFF.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(OrderHandler orderHandler) : ControllerBase
    {
        private readonly OrderHandler _orderHandler = orderHandler;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? request = null)
        {
            var result = await _orderHandler.HandleGetAsync(request);
            return result is not null ? Ok(result) : StatusCode(500, "Failed to fetch order status.");
        }

        [Authorize(Policy = "RequireApiAccessScope")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string? request = null)
        {
            var result = await _orderHandler.HandlePostAsync(request);
            return result is not null ? Ok(result) : StatusCode(500, "Failed to process order.");
        }
    }
}
