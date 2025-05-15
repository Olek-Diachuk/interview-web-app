using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Payment_Service_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(500);
            return Ok( new { data = "Payment GET result" });
        }
        
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await Task.Delay(600); 
            return Ok(new { data = "Payment check complete" });
        }
    }
}
