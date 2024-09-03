using CurrencyConverter.API.Models.Frankfurter;

namespace CurrencyConverter.API.Frankfurter
{
    public class FrankfurterApiClientBase
    {
        HttpClient _httpClient;
        protected FrankfurterApiClientBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        protected async Task<ExchangeApiResponse> GetAsync(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var exchangeApiResponse = await response.Content.ReadFromJsonAsync<ExchangeApiResponse>();
            return exchangeApiResponse;
        }

    }
}
