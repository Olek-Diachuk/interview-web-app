using BFF.DTOs;

namespace BFF.Handlers
{
    public class PaymentHandler(Func<string, HttpHandler> httpHandlerFactory) : IApiRequestHandler<string, ApiResponseDto>
    {
        private readonly HttpHandler _httpPaymentHandler = httpHandlerFactory("payment");

        public async Task<ApiResponseDto?> HandleGetAsync(string? request)
        {
            return await _httpPaymentHandler.HandleAsync<string, ApiResponseDto>("GET", "/api/payment", request);
        }

        public async Task<ApiResponseDto?> HandlePostAsync(string? request)
        {
            return await _httpPaymentHandler.HandleAsync<string, ApiResponseDto>("POST", "/api/payment", request);
        }
    }
}
