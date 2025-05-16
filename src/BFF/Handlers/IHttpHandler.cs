
namespace BFF.Handlers
{
    public interface IHttpHandler
    {
        Task<TResponse?> HandleAsync<TPayload, TResponse>(string method, string resource, TPayload? payload = default);
    }
}