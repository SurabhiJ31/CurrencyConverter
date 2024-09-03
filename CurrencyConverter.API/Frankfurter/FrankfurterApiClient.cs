
using CurrencyConverter.API.Models.Frankfurter;

namespace CurrencyConverter.API.Frankfurter
{
    public class FrankfurterApiClient : FrankfurterApiClientBase, IBaseApiClient
    {
        public FrankfurterApiClient(HttpClient httpClient):base(httpClient)
        {
        }

        public async Task<ExchangeApiResponse> GetLatestExchangeRatesAsync()
        {
            return await GetAsync("latest");
        }

        public async Task<ExchangeApiResponse> ConvertAmountAsync(string fromCurrency, decimal fromAmount, string toCurrency)
        {
            return await GetAsync($"latest?amount={fromAmount}&from={fromCurrency}&to={toCurrency}");
        }

        public async Task<ExchangeApiResponse> GetHistoricalExchangeRatesAsync(string fromDate, string endDate, string toCurrency)
        {
            return await GetAsync($"{fromDate}..{endDate}?to={toCurrency}");
        }
    }
}
