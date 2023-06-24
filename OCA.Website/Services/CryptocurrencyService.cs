using Newtonsoft.Json;
using OCA.Website.Interfaces;
using OCA.Website.Models;

namespace OCA.Website.Services
{
    internal class CryptocurrencyService : ICryptocurrency
    {
        private readonly ILogger<CryptocurrencyService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public CryptocurrencyService(ILogger<CryptocurrencyService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Cryptocurrency>> Get()
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("CIP.API");
                HttpResponseMessage httpResponseMessage = await client.GetAsync("cip/cryptocurrencies/get");

                if(httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    _logger.LogError("Bad request in {MethodName}, StatusCode: {StatusCode}", System.Reflection.MethodBase.GetCurrentMethod()?.Name, httpResponseMessage.StatusCode);
                    return Enumerable.Empty<Cryptocurrency>();
                }

                string cryptocurrenciesJson = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Cryptocurrency>>(cryptocurrenciesJson) ?? Enumerable.Empty<Cryptocurrency>();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{MethodName}", System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            }
            return Enumerable.Empty<Cryptocurrency>();  
        }
    }
}
