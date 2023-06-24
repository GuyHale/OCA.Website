using Newtonsoft.Json;
using OCA.Website.Helpers;
using OCA.Website.Interfaces;
using OCA.Website.Models;

namespace OCA.Website.Services
{
    public class ApiKeyCreation : IApiKeyCreation
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ApiKeyCreation> _logger;

        public ApiKeyCreation(IHttpClientFactory httpClientFactory, ILogger<ApiKeyCreation> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<ICustomResponse> CreateApiKey(string apiKey)
        {
            HttpClient client = _httpClientFactory.CreateClient("CIP.API");
            HttpResponseMessage httpResponseMessage = await client.GetAsync($"cip/apikey/create/{apiKey}");

            if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _logger.LogError("Bad request in {MethodName}, StatusCode: {StatusCode}", System.Reflection.MethodBase.GetCurrentMethod()?.Name, httpResponseMessage.StatusCode);
                return ResponseHelpers.ServerError<ApiKeyCreationResponse>();
            }

            string apiKeyCreationResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiKeyCreationResponse>(apiKeyCreationResponse) ?? ResponseHelpers.ServerError<ApiKeyCreationResponse>();
        }
    }
}
