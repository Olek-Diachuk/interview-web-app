using BFF.DTOs;

namespace BFF.Handlers
{
    public class OrderHandler(InventoryHandler inventoryHandler, PaymentHandler paymentHandler) : IApiRequestHandler<string, OrderResponseDto>
    {
        public async Task<OrderResponseDto?> HandleGetAsync(string? request)
        {
            var inventoryResult = await inventoryHandler.HandleGetAsync(request);
            if (inventoryResult is null)
            {
                // Inventory check failed
                return default;
            }
            //some logic based on the response

            var paymentResult = await paymentHandler.HandleGetAsync(request);
            if (paymentResult is null)
            {
                // Payment status check failed
                return default;
            }

            //some logic based on the response

            OrderResponseDto result = new()
            {
                Inventory = inventoryResult.Data,
                Payment = paymentResult.Data
            };

            return result;
        }

        public async Task<OrderResponseDto?> HandlePostAsync(string? request)
        {
            var inventoryTask = inventoryHandler.HandlePostAsync(request);
            var paymentTask = paymentHandler.HandlePostAsync(request);

            await Task.WhenAll(inventoryTask, paymentTask);

            var inventoryResult = inventoryTask.Result;
            var paymentResult = paymentTask.Result;

            if (inventoryResult is null || paymentResult is null)
            {
                return default;
            }

            OrderResponseDto result = new()
            {
                Inventory = inventoryResult.Data,
                Payment = paymentResult.Data
            };

            return result;
        }
    }
}
