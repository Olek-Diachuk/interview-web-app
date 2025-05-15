using BFF.DTOs;

namespace BFF.Handlers
{
    public class InventoryHandler(Func<string, HttpHandler> httpHandlerFactory) : IApiRequestHandler<string, ApiResponseDto>
    {
        private readonly HttpHandler _httpHandler = httpHandlerFactory("inventory");

        public async Task<ApiResponseDto?> HandleGetAsync(string? request)
        {
            return await _httpHandler.HandleAsync<string, ApiResponseDto>("GET", "/api/inventory", request);
        }


        public async Task<ApiResponseDto?> HandlePostAsync(string? request)
        {
            return await _httpHandler.HandleAsync<string, ApiResponseDto>("POST", "/api/inventory", request);
        }
    }

}