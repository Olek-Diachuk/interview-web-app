using Microsoft.AspNetCore.Mvc;

namespace Inventory_Service_API.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(500);
            return Ok(new { data = "Inventory GET result" } );
        }

        [HttpPost()]
        public async Task<IActionResult> Post()
        {
            await Task.Delay(700);
            return Ok(new { data = "Inventory check complete" } );
        }
    }
}
