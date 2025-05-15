
namespace BFF.Handlers
{
    public class HttpHandler(HttpClient http) : IHttpHandler
    {
        protected readonly HttpClient _http = http;

        public async Task<TResponse?> HandleAsync<TPayload, TResponse>(string method, string resource, TPayload? payload = default)
        {
            HttpResponseMessage response;

            switch (method)
            {
                case "GET":
                    {
                        if(payload is not null)
                        {
                            //convert to query string
                        }
                        response = await _http.GetAsync(resource);
                        break;
                    }
                  

                case "POST":
                    {
                        response = await _http.PostAsJsonAsync(resource, payload);
                        break;
                    }
    

                default:
                    throw new NotSupportedException($"HTTP method '{method}' is not supported.");
            }

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            return await response.Content.ReadFromJsonAsync<TResponse>();
        }
    }
}
