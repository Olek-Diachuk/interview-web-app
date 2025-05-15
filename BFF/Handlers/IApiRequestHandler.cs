
using BFF.DTOs;

namespace BFF.Handlers
{
    public interface IApiRequestHandler<TRequest, TResponse>
    {
        Task<TResponse?> HandleGetAsync(TRequest request);
        Task<TResponse?> HandlePostAsync(TRequest request);
    }
}